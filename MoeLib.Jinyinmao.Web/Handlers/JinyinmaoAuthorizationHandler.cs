using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Web.Auth;

namespace MoeLib.Jinyinmao.Web.Handlers
{
    /// <summary>
    ///     JinyinmaoAuthorizationHandler.
    /// </summary>
    public class JinyinmaoAuthorizationHandler : DelegatingHandler
    {
        private readonly JYMAccessTokenProtector accessTokenProtector;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoAuthorizationHandler" /> class.
        /// </summary>
        /// <param name="bearerKeys">The bearerKeys.</param>
        public JinyinmaoAuthorizationHandler(string bearerKeys)
        {
            this.accessTokenProtector = new JYMAccessTokenProtector(bearerKeys);
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoAuthorizationHandler" /> class.
        /// </summary>
        /// <param name="bearerKeys">The bearerKeys.</param>
        /// <param name="governmentServerPublicKey">The government server public key.</param>
        public JinyinmaoAuthorizationHandler(string bearerKeys, string governmentServerPublicKey)
        {
            this.accessTokenProtector = new JYMAccessTokenProtector(bearerKeys);
            this.GovernmentServerPublicKey = governmentServerPublicKey;
        }

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
                RSACryptoServiceProvider provider = new RSACryptoServiceProvider(2048);
                provider.FromXmlString(this.GovernmentServerPublicKey);
                return provider;
            }
        }

        private ClaimsIdentity Identity
        {
            get { return HttpContext.Current.User.Identity as ClaimsIdentity; }
            set { HttpContext.Current.User = new ClaimsPrincipal(value); }
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
            else
            {
                this.AuthorizeUserViaCustomHeader(request);
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            this.GenerateAndSetAccessToken(request, response);

            return response;
        }

        private static bool HasAuthorizationHeader(HttpRequestMessage request, string scheme)
        {
            return request.Headers.Authorization?.Scheme != null &&
                   string.Equals(request.Headers.Authorization.Scheme, scheme, StringComparison.OrdinalIgnoreCase);
        }

        private void AuthorizeApplicationViaAuthToken(HttpRequestMessage request)
        {
            string token = request.Headers.Authorization?.Parameter;
            string[] tokenPiece = token?.Split(',');
            if (tokenPiece?.Length == 5)
            {
                string ticket = tokenPiece.Take(4).Join(",");
                string sign = tokenPiece[4];
                if (this.CryptoServiceProvider.VerifyData(ticket.GetBytesOfASCII(), new SHA1CryptoServiceProvider(), sign.ToBase64Bytes()))
                {
                    if (tokenPiece[3].AsLong(0) > DateTime.UtcNow.UnixTimestamp() && tokenPiece[2] == App.Host.Role)
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
            if (HasAuthorizationHeader(request, JYMAuthScheme.Bearer) && request.Headers.Authorization?.Parameter == null && this.Identity != null && this.Identity.IsAuthenticated)
            {
                Claim claim = this.Identity.FindFirst(ClaimTypes.Expiration);
                long timestamp = claim?.Value?.AsLong() ?? DateTime.UtcNow.UnixTimestamp();

                response.Content = request.CreateResponse(HttpStatusCode.OK, new
                {
                    access_token = this.accessTokenProtector.Protect(this.Identity),
                    expiration = timestamp
                }).Content;
            }
        }
    }
}