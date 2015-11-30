using MoeLib.Diagnostics;
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
    }
}