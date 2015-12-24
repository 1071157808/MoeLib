using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moe.Lib;
using Moe.Lib.Web;
using Newtonsoft.Json.Linq;

namespace MoeLib.Jinyinmao.Web.Handlers.Server
{
    /// <summary>
    ///     JinyinmaoJsonResponseWapperHandler.
    /// </summary>
    public class JinyinmaoJsonResponseWarpperHandler : DelegatingHandler
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
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            if (request.GetQueryString("jw").IsNotNullOrEmpty() && request.Headers.Accept.Any(a => a.MediaType == "application/json" || a.MediaType == "*/*") &&
                (response.Content == null || response.Content.Headers.ContentType.MediaType == "application/json"))
            {
                await WappUpContent(request, response);
            }

            return response;
        }

        private static async Task WappUpContent(HttpRequestMessage request, HttpResponseMessage response)
        {
            string content = null;
            if (response.Content != null)
            {
                content = await response.Content.ReadAsStringAsync();
            }
            if (content.IsNullOrEmpty())
            {
                content = "{}";
            }

            JToken jToken = JToken.Parse(content);
            JObject jObject = new JObject
            {
                { "retCode", (response.IsSuccessStatusCode ? "00" : "10") + (int)response.StatusCode },
                { "retMsg", response.IsSuccessStatusCode ? "ok" : jToken.SelectToken("message", false)?.Value<string>() ?? "" },
                { "data", jToken }
            };

            response.Content = request.CreateResponse(HttpStatusCode.OK, jObject).Content;
        }
    }
}