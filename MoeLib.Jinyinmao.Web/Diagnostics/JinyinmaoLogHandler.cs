using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moe.Lib;
using Moe.Lib.Jinyinmao;

namespace MoeLib.Jinyinmao.Web.Diagnostics
{
    public class JinyinmaoLogHandler : DelegatingHandler
    {
        private static readonly Lazy<IWebLogger> logger = new Lazy<IWebLogger>(() => InitApplicationLogger());

        private IWebLogger Logger
        {
            get { return logger.Value; }
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
            IEnumerable<string> clientId = null;
            IEnumerable<string> deviceId = null;
            IEnumerable<string> requestId = null;
            IEnumerable<string> sessionId = null;
            IEnumerable<string> userId = null;

            if (request?.Headers != null)
            {
                request.Headers.TryGetValues("X-JYM-CID", out clientId);
                request.Headers.TryGetValues("X-JYM-DID", out deviceId);
                request.Headers.TryGetValues("X-JYM-RID", out requestId);
                request.Headers.TryGetValues("X-JYM-SID", out sessionId);
                request.Headers.TryGetValues("X-JYM-UID", out userId);
            }

            string clientIdString = clientId?.Join(",");
            string deviceIdString = deviceId?.Join(",");
            string requestIdString = requestId?.Join(",");
            string sessionIdString = sessionId?.Join(",");
            string userIdString = userId?.Join(",");

            requestIdString = requestIdString ?? Guid.NewGuid().ToGuidString();

            this.Logger.Info($"Request Begin: {requestIdString}", request, clientIdString, deviceIdString,
                requestIdString, sessionIdString, userIdString, "ASP.NET HTTP Request", 0UL, string.Empty);

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            Dictionary<string, object> payload = new Dictionary<string, object>
            {
                { "ResponseStatusCode", response.StatusCode }
            };

            if (response.Content != null)
            {
                payload.Add("ResponseContent", (await response.Content.ReadAsStringAsync()).GetFirst(30000));
            }

            this.Logger.Info($"Request End: {requestIdString}", request, clientIdString, deviceIdString,
                requestIdString, sessionIdString, userIdString, "ASP.NET HTTP Response", 0UL, string.Empty, null, payload);

            return response;
        }

        private static IWebLogger InitApplicationLogger()
        {
            return App.LogManager.CreateWebLogger();
        }
    }
}