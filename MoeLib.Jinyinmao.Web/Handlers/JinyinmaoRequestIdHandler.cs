using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moe.Lib;

namespace MoeLib.Jinyinmao.Web.Handlers
{
    public class JinyinmaoRequestIdHandler : DelegatingHandler
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
            if (request?.Headers != null)
            {
                if (!request.Headers.Contains("X-JYM-RID"))
                {
                    request.Headers.TryAddWithoutValidation("X-JYM-RID", GuidUtility.NewSequentialGuid().ToGuidString());
                }
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}