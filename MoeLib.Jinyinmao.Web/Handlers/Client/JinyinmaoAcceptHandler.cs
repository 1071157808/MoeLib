using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace MoeLib.Jinyinmao.Web.Handlers.Client
{
    /// <summary>
    ///     JinyinmaoAcceptHandler.
    /// </summary>
    public class JinyinmaoAcceptHandler : DelegatingHandler
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
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 0.8));
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.2));
            return await base.SendAsync(request, cancellationToken);
        }
    }
}