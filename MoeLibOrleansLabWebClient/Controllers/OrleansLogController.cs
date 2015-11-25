using System;
using System.Threading.Tasks;
using System.Web.Http;
using MoeLib.Jinyinmao.Orleans;
using MoeLibOrleansLabIGrain;
using Orleans;

namespace MoeLibOrleansLabWebClient.Controllers
{
    [RoutePrefix("Log")]
    public class OrleansLogController : ApiControllerBase
    {
        [HttpGet, Route("Exception")]
        public async Task<IHttpActionResult> GetException()
        {
            ILogGrain logGrain = GrainClient.GrainFactory.GetGrain<ILogGrain>(Guid.NewGuid());
            return this.Ok(await logGrain.WithTraceEntry(this.Request).ExceptionAsync());
        }

        [HttpGet, Route("Trace")]
        public async Task<IHttpActionResult> GetTrace()
        {
            ILogGrain logGrain = GrainClient.GrainFactory.GetGrain<ILogGrain>(Guid.NewGuid());
            return this.Ok(await logGrain.WithTraceEntry(this.Request).TraceAsync());
        }
    }
}