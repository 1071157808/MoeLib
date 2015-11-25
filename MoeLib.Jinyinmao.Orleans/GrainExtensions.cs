using System.Net.Http;
using MoeLib.Diagnostics;
using MoeLib.Jinyinmao.Web.Diagnostics;
using Orleans;
using Orleans.Runtime;

namespace MoeLib.Jinyinmao.Orleans
{
    /// <summary>
    ///     GrainExtensions.
    /// </summary>
    public static class GrainExtensions
    {
        /// <summary>
        ///     Set the <see cref="TraceEntry" /> to the RequestConxt.
        /// </summary>
        /// <typeparam name="TGrain">The type of the <see cref="IGrain" /> instance.</typeparam>
        /// <param name="grain">The instance of <see cref="IGrain" />.</param>
        /// <param name="traceEntry">The instance of <see cref="TraceEntry" />.</param>
        /// <returns>TGrain.</returns>
        public static TGrain WithTraceEntry<TGrain>(this TGrain grain, TraceEntry traceEntry) where TGrain : IGrain
        {
            RequestContext.Set("TraceEntry", traceEntry);
            return grain;
        }

        /// <summary>
        ///     Set the <see cref="TraceEntry" /> from the <see cref="HttpRequestMessage" /> to the RequestConxt.
        /// </summary>
        /// <typeparam name="TGrain">The type of the <see cref="IGrain" /> instance.</typeparam>
        /// <param name="grain">The instance of <see cref="IGrain" />.</param>
        /// <param name="request">The instance of <see cref="HttpRequestMessage" />.</param>
        /// <returns>TGrain.</returns>
        public static TGrain WithTraceEntry<TGrain>(this TGrain grain, HttpRequestMessage request) where TGrain : IGrain
        {
            return grain.WithTraceEntry(request.GetTraceEntry());
        }
    }
}