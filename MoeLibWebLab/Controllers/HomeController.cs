using System.Web.Http;
using System.Web.Http.Tracing;

namespace MoeLibWebLab.Controllers
{
    public class HomeController : ApiController
    {
        [Route("")]
        public string Get(int id)
        {
            ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();
        }
    }
}