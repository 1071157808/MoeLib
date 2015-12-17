using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Azure;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Web.Auth;
using MoeLib.Web;

namespace MoeLib.Jinyinmao.Web.Handlers.Server
{
    /// <summary>
    ///     JinyinmaoAuthorizationHandler.
    /// </summary>
    public class JinyinmaoAuthorizationHandler : DelegatingHandler
    {
        private const string CRYPTO_SERVICE_PROVIDER_ERROR_MESSAGE = "JinyinmaoAuthorizationHandler CryptoServiceProvider can not initialize. The GovernmentServerPublicKey may be in bad format. GovernmentServerPublicKey: {0}";
        private readonly JYMAccessTokenProtector accessTokenProtector;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoAuthorizationHandler" /> class.
        /// </summary>
        /// <param name="bearerAuthKeys">The bearerAuthKeys.</param>
        public JinyinmaoAuthorizationHandler(string bearerAuthKeys)
        {
            this.accessTokenProtector = new JYMAccessTokenProtector(bearerAuthKeys);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoAuthorizationHandler" /> class.
        /// </summary>
        /// <param name="bearerAuthKeys">The bearerAuthKeys.</param>
        /// <param name="governmentServerPublicKey">The government server public key.</param>
        public JinyinmaoAuthorizationHandler(string bearerAuthKeys, string governmentServerPublicKey)
        {
            this.accessTokenProtector = new JYMAccessTokenProtector(bearerAuthKeys);
            this.GovernmentServerPublicKey = governmentServerPublicKey;
        }

        /// <summary>
        ///     Gets a value indicating whether [use swagger as application for dev].
        /// </summary>
        /// <value><c>true</c> if [use swagger as application for dev]; otherwise, <c>false</c>.</value>
        public static bool UseSwaggerAsApplicationForDev { get; } = CloudConfigurationManager.GetSetting("UseSwaggerAsApplicationForDev").AsBoolean(false);

        /// <summary>
        ///     Gets or sets the government server public key.
        /// </summary>
        /// <value>The government server public key.</value>
        public string GovernmentServerPublicKey { get; set; }

        private RSACryptoServiceProvider CryptoServiceProvider
        {
            get
            {
                if (this.GovernmentServerPublicKey.IsNullOrEmpty())
                {
                    return null;
                }
                try
                {
                    RSACryptoServiceProvider provider = new RSACryptoServiceProvider(2048);
                    provider.FromXmlString(this.GovernmentServerPublicKey);
                    return provider;
                }
                catch (Exception e)
                {
                    throw new ConfigurationErrorsException(CRYPTO_SERVICE_PROVIDER_ERROR_MESSAGE.FormatWith(this.GovernmentServerPublicKey), e);
                }
            }
        }

        private ClaimsIdentity Identity
        {
            get { return HttpContext.Current.User?.Identity as ClaimsIdentity; }
            set { HttpContext.Current.User = new ClaimsPrincipal(value); }
        }

        private List<string> IPWhitelists
        {
            get { return App.Configurations.GetIPWhitelists(); }
        }

        /// <summary>
        ///     Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <returns>
        ///     Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.
        /// </returns>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="request" /> was null.</exception>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (HasAuthorizationHeader(request, JYMAuthScheme.Bearer) && request.Headers.Authorization?.Parameter != null)
            {
                this.AuthorizeUserViaBearerToken(request);
            }
            else if (this.GovernmentServerPublicKey != null && HasAuthorizationHeader(request, JYMAuthScheme.JYMInternalAuth))
            {
                this.AuthorizeApplicationViaAuthToken(request);
            }
            else if (UseSwaggerAsApplicationForDev && this.IsFromSwagger(request))
            {
                this.AuthorizeApplicationIfFromSwagger();
            }
            else if (this.IsFromWhitelists(request))
            {
                this.AuthorizeApplicationIfFromWhitelistst(request);
            }
            else if (this.IsFromLocalhost(request))
            {
                this.AuthorizeApplicationIfFromLocalhost();
            }
            else
            {
                this.AuthorizeUserViaCustomHeader(request);
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (HasAuthorizationHeader(request, JYMAuthScheme.Bearer) && request.Headers.Authorization?.Parameter == null && this.Identity != null && this.Identity.IsAuthenticated)
            {
                this.GenerateAndSetAccessToken(request, response);
            }

            return response;
        }

        private static bool HasAuthorizationHeader(HttpRequestMessage request, string scheme)
        {
            return request.Headers.Authorization?.Scheme != null &&
                   string.Equals(request.Headers.Authorization.Scheme, scheme, StringComparison.OrdinalIgnoreCase);
        }

        private void AuthorizeApplicationIfFromLocalhost()
        {
            this.Identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Localhost"),
                new Claim(ClaimTypes.Role, "Application")
            }, JYMAuthScheme.JYMInternalAuth);
        }

        private void AuthorizeApplicationIfFromSwagger()
        {
            this.Identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Swagger"),
                new Claim(ClaimTypes.Role, "Application")
            }, JYMAuthScheme.JYMInternalAuth);
        }

        private void AuthorizeApplicationIfFromWhitelistst(HttpRequestMessage request)
        {
            string ip = request.GetUserHostAddress();
            this.Identity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, $"IP: {ip}"),
                new Claim(ClaimTypes.Role, "Application")
            }, JYMAuthScheme.JYMInternalAuth);
        }

        private void AuthorizeApplicationViaAuthToken(HttpRequestMessage request)
        {
            string token = request.Headers.Authorization?.Parameter.ToBase64Bytes().ASCII();
            string[] tokenPiece = token?.Split(',');
            if (tokenPiece?.Length == 5)
            {
                string ticket = tokenPiece.Take(4).Join(",");
                string sign = tokenPiece[4];
                if (this.CryptoServiceProvider.VerifyData(ticket.GetBytesOfASCII(), new SHA1CryptoServiceProvider(), sign.ToBase64Bytes()))
                {
                    if (tokenPiece[3].AsLong(0) > DateTime.UtcNow.UnixTimestamp() && tokenPiece[1] == App.Host.Role)
                    {
                        this.Identity = new ClaimsIdentity(new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, tokenPiece[0]),
                            new Claim(ClaimTypes.Role, "Application")
                        }, JYMAuthScheme.JYMInternalAuth);
                    }
                }
            }
        }

        private void AuthorizeUserViaBearerToken(HttpRequestMessage request)
        {
            this.Identity = this.accessTokenProtector.Unprotect(request.Headers.Authorization.Parameter);
        }

        private void AuthorizeUserViaCustomHeader(HttpRequestMessage request)
        {
            IEnumerable<string> authHeader;
            if (request.Headers.TryGetValues("X-JYM-AUTH", out authHeader))
            {
                this.Identity = this.accessTokenProtector.Unprotect(authHeader.FirstOrDefault());
            }
        }

        private void GenerateAndSetAccessToken(HttpRequestMessage request, HttpResponseMessage response)
        {
            Claim claim = this.Identity.FindFirst(ClaimTypes.Expiration);
            long timestamp = claim?.Value?.AsLong() ?? DateTime.UtcNow.UnixTimestamp();

            response.Content = request.CreateResponse(HttpStatusCode.OK, new
            {
                access_token = this.accessTokenProtector.Protect(this.Identity),
                expiration = timestamp
            }).Content;
        }

        private bool IsFromLocalhost(HttpRequestMessage request)
        {
            return request.IsLocal();
        }

        private bool IsFromSwagger(HttpRequestMessage request)
        {
            if (request.Headers.Referrer != null)
            {
                return request.Headers.Referrer.AbsoluteUri.Contains("swagger", StringComparison.OrdinalIgnoreCase);
            }
            return false;
        }

        private bool IsFromWhitelists(HttpRequestMessage request)
        {
            return this.IPWhitelists != null && this.IPWhitelists.Contains(request.GetUserHostAddress());
        }
    }
}