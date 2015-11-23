using System.Net.Http;
using Moe.Lib.Web;

namespace MoeLib.Web
{
    /// <summary>
    ///     HttpRequestMessageExtensions.
    /// </summary>
    public static class HttpRequestMessageExtensions
    {
        /// <summary>
        ///     Gets the user agent.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.String.</returns>
        public static string GetUserAgent(this HttpRequestMessage request)
        {
            return HttpUtils.GetUserAgent(request);
        }

        /// <summary>
        ///     Gets the user host address.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.String.</returns>
        public static string GetUserHostAddress(this HttpRequestMessage request)
        {
            return HttpUtils.GetUserHostAddress(request);
        }
    }
}