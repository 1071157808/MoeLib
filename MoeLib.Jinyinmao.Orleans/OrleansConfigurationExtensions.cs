using MoeLib.Diagnostics;
using Orleans;
using Orleans.Runtime;

namespace MoeLib.Jinyinmao.Orleans
{
    /// <summary>
    ///     OrleansConfigurationExtensions.
    /// </summary>
    public static class OrleansConfigurationExtensions
    {
        /// <summary>
        ///     Withes the trace entry.
        /// </summary>
        /// <param name="grain">The grain.</param>
        /// <param name="traceEntry">The trace entry.</param>
        public static void WithTraceEntry(this IGrain grain, TraceEntry traceEntry)
        {
            RequestContext.Set("TraceEntry", traceEntry);
        }
    }
}