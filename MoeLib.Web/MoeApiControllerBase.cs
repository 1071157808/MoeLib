using System.Web.Http;
using System.Web.Http.Tracing;

namespace MoeLib.Web
{
    /// <summary>
    ///     MoeApiControllerBase.
    /// </summary>
    public abstract class MoeApiControllerBase : ApiController
    {
        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public ITraceWriter Logger
        {
            get { return this.Configuration.Services.GetTraceWriter(); }
        }
    }
}