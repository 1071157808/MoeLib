using System.Net.Http;
using Moe.Lib;
using MoeLib.Diagnostics;
using MoeLib.Web;

namespace MoeLib.Jinyinmao.Web.Diagnostics
{
    /// <summary>
    ///     HttpRequestMessageExtensions.
    /// </summary>
    public static class HttpRequestMessageExtensions
    {
        /// <summary>
        ///     Gets the trace entry.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>MoeLib.Diagnostics.TraceEntry.</returns>
        public static TraceEntry GetTraceEntry(this HttpRequestMessage request)
        {
            return request.To(r => new TraceEntry
            {
                ClientId = request?.GetHeader("X-JYM-CID"),
                DeviceId = request?.GetHeader("X-JYM-DID"),
                RequestId = request?.GetHeader("X-JYM-RID"),
                SessionId = request?.GetHeader("X-JYM-SID"),
                SourceIP = request?.GetHeader("X-JYM-IP") ?? request?.GetUserHostAddress(),
                SourceUserAgent = request?.GetHeader("X-JYM-UA") ?? request?.GetUserAgent(),
                UserId = request?.GetHeader("X-JYM-UID")
            });
        }
    }
}