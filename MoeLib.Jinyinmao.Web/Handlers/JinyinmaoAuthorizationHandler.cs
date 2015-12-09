using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Moe.Lib;
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
        /// <param name="keys">The keys.</param>
        public JinyinmaoAuthorizationHandler(string keys)
        {
            this.accessTokenProtector = new JYMAccessTokenProtector(keys);
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
            if (request.Headers.Authorization?.Scheme != null &&
                string.Equals(request.Headers.Authorization.Scheme, JYMAuthScheme.Bearer, StringComparison.OrdinalIgnoreCase))
            {
                this.Identity = this.accessTokenProtector.Unprotect(request.Headers.Authorization.Parameter);
            }
            else
            {
                IEnumerable<string> authHeader;
                if (request.Headers.TryGetValues("X-JYM-AUTH", out authHeader))
                {
                    this.Identity = this.accessTokenProtector.Unprotect(authHeader.FirstOrDefault());
                }
            }

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (request.Headers.Authorization?.Scheme != null &&
                !string.Equals(request.Headers.Authorization.Scheme, JYMAuthScheme.Bearer, StringComparison.OrdinalIgnoreCase)
                && this.Identity != null && this.Identity.IsAuthenticated)
            {
                Claim claim = this.Identity.FindFirst(ClaimTypes.Expiration);
                long timestamp = claim?.Value?.AsLong() ?? DateTime.UtcNow.UnixTimestamp();

                response.Content = request.CreateResponse(HttpStatusCode.OK, new
                {
                    access_token = this.accessTokenProtector.Protect(this.Identity),
                    expiration = timestamp
                }).Content;
            }

            return response;
        }
    }
}