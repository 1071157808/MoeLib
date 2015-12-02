using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace MoeLib.Jinyinmao.Web.Handlers
{
    /// <summary>
    ///     JinyinmaoAuthHandler.
    /// </summary>
    public class JinyinmaoAuthHandler : DelegatingHandler
    {
        private IPrincipal User
        {
            get { return HttpContext.Current.User; }
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
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            this.OnRequest(request);
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            this.OnResponse(request, response);

            return response;
        }

        private void OnRequest(HttpRequestMessage request)
        {
        }

        private void OnResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            if (request.Headers.Accept.Contains(new MediaTypeWithQualityHeaderValue("application/json")))
            {
            }
        }
    }
}