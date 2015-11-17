using System;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace MoeLibWebLab.Controllers
{
    [RoutePrefix("Log")]
    public class LogController : ApiController
    {
        [Route("Exception")]
        public IHttpActionResult Exception()
        {
            throw new ApplicationException("This is for testing exception logger",
                new ApplicationException("This is the first inner exception.", new ApplicationException("This is the second inner exception.")));
        }

        [Route("Trace")]
        public IHttpActionResult Trace()
        {
            ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();
            traceWriter.Debug(this.Request, "Debug", "This is the log message of Debug level.");
            traceWriter.Info(this.Request, "Info", "This is the log message of Info level.");
            traceWriter.Warn(this.Request, "Warn", "This is the log message of Warn level.");
            traceWriter.Error(this.Request, "Error", "This is the log message of Error level.");
            traceWriter.Fatal(this.Request, "Fatal", "This is the log message of Fatal level.");

            traceWriter.Debug(this.Request, "Debug",
                new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Debug level.");
            traceWriter.Info(this.Request, "Info",
                new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Info level.");
            traceWriter.Warn(this.Request, "Warn",
                new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Warn level.");
            traceWriter.Error(this.Request, "Error",
                new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Error level.");
            traceWriter.Fatal(this.Request, "Fatal",
                new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Fatal level.");

            return this.Ok();
        }
    }
}