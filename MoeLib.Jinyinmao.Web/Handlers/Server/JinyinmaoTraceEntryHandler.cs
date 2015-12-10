using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moe.Lib;
using MoeLib.Web;

namespace MoeLib.Jinyinmao.Web.Handlers.Server
{
    /// <summary>
    ///     JinyinmaoTraceEntryHandler.
    /// </summary>
    public class JinyinmaoTraceEntryHandler : DelegatingHandler
    {
        /// <summary>
        ///     Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <returns>
        ///     Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.
        /// </returns>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="request" /> was null.</exception>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (!request.Headers.Contains("X-JYM-CID"))
            {
                request.Headers.TryAddWithoutValidation("X-JYM-CID", "0");
            }

            if (!request.Headers.Contains("X-JYM-DID"))
            {
                request.Headers.TryAddWithoutValidation("X-JYM-DID", "0");
            }

            if (!request.Headers.Contains("X-JYM-RID"))
            {
                request.Headers.TryAddWithoutValidation("X-JYM-RID", Guid.NewGuid().ToGuidString());
            }

            if (!request.Headers.Contains("X-JYM-SID"))
            {
                request.Headers.TryAddWithoutValidation("X-JYM-SID", Guid.NewGuid().ToGuidString());
            }

            if (!request.Headers.Contains("X-JYM-IP"))
            {
                request.Headers.TryAddWithoutValidation("X-JYM-IP", request.GetUserHostAddress());
            }

            if (!request.Headers.Contains("X-JYM-UA"))
            {
                request.Headers.TryAddWithoutValidation("X-JYM-UA", request.GetUserAgent());
            }

            if (!request.Headers.Contains("X-JYM-UID"))
            {
                request.Headers.TryAddWithoutValidation("X-JYM-UID", "Anonymous");
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}