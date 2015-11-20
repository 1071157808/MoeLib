using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;
using System.Web.Http.Tracing;
using MoeLib.Jinyinmao.Web.Diagnostics;

namespace MoeLibWebLab.Controllers
{
    [RoutePrefix("Log")]
    public class LogController : ApiController
    {
        [HttpGet, Route("Exception")]
        public IHttpActionResult GetException()
        {
            throw new ApplicationException("This is for testing exception logger",
                new ApplicationException("This is the first inner exception.", new ApplicationException("This is the second inner exception.")));
        }

        [HttpGet, Route("Trace")]
        public IHttpActionResult GetTrace()
        {
            ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();
            traceWriter.Debug(this.Request, "This is the log message of Debug level.");
            traceWriter.Info(this.Request, "This is the log message of Info level.");
            traceWriter.Warn(this.Request, "This is the log message of Warn level.");
            traceWriter.Error(this.Request, "This is the log message of Error level.");
            traceWriter.Fatal(this.Request, "This is the log message of Fatal level.");

            traceWriter.Debug(this.Request, new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Debug level.");
            traceWriter.Info(this.Request, new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Info level.");
            traceWriter.Warn(this.Request, new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Warn level.");
            traceWriter.Error(this.Request, new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Error level.");
            traceWriter.Fatal(this.Request, new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Fatal level.");

            return this.Ok();
        }

        [HttpPost, Route("Exception")]
        public IHttpActionResult PostException(RequestData request)
        {
            throw new ApplicationException("This is for testing exception logger",
                new ApplicationException("This is the first inner exception.", new ApplicationException("This is the second inner exception.")));
        }

        [HttpPost, Route("Trace")]
        public IHttpActionResult PostTrace(RequestData request)
        {
            ITraceWriter traceWriter = this.Configuration.Services.GetTraceWriter();
            traceWriter.Debug(this.Request, "This is the log message of Debug level.");
            traceWriter.Info(this.Request, "This is the log message of Info level.");
            traceWriter.Warn(this.Request, "This is the log message of Warn level.");
            traceWriter.Error(this.Request, "This is the log message of Error level.");
            traceWriter.Fatal(this.Request, "This is the log message of Fatal level.");

            traceWriter.Debug(this.Request, new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Debug level.");
            traceWriter.Info(this.Request, new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Info level.");
            traceWriter.Warn(this.Request, new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Warn level.");
            traceWriter.Error(this.Request, new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Error level.");
            traceWriter.Fatal(this.Request, new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Fatal level.");

            return this.Ok(request);
        }
    }

    public class RequestData
    {
        [Required]
        public Dictionary<string, object> DictionaryData { get; set; }

        [Required]
        public int IntData { get; set; }

        [Required]
        public string StringData { get; set; }
    }
}