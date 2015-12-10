using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using Moe.Lib;
using Moe.Lib.TransientFaultHandling;

namespace MoeLib.Jinyinmao.Web.Handlers.Client
{
    /// <summary>
    ///     JinyinmaoRetryHandler.
    /// </summary>
    public class JinyinmaoRetryHandler : DelegatingHandler
    {
        private static readonly RetryPolicy retryPolicy = new RetryPolicy(new HttpRequestTransientErrorDetectionStrategy(), 5, 3.Seconds());

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
            return retryPolicy.ExecuteAction(() => base.SendAsync(request, cancellationToken));
        }
    }
}