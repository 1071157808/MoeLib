using MoeLib.Diagnostics;
using Orleans;
using Orleans.Runtime;

namespace MoeLib.Jinyinmao.Orleans
{
    public static class OrleansConfigurationExtensions
    {
        public static void WithTraceEntry(this IGrain grain, TraceEntry traceEntry)
        {
            RequestContext.Set("TraceEntry", traceEntry);
        }
    }
}