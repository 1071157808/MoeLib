// ***********************************************************************
// Project          : MoeLib
// File             : LogController.cs
// Created          : 2015-11-20  5:55 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  1:03 AM
// ***********************************************************************
// <copyright file="LogController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;

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
            this.Debug("This is the log message of Debug level.");
            this.Info("This is the log message of Info level.");
            this.Warn("This is the log message of Warn level.");
            this.Error("This is the log message of Error level.");
            this.Fatal("This is the log message of Fatal level.");

            this.Debug(new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Debug level.");
            this.Info(new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Info level.");
            this.Warn(new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Warn level.");
            this.Error(new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Error level.");
            this.Fatal(new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
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
            this.Debug("This is the log message of Debug level.");
            this.Info("This is the log message of Info level.");
            this.Warn("This is the log message of Warn level.");
            this.Error("This is the log message of Error level.");
            this.Fatal("This is the log message of Fatal level.");

            this.Debug(new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Debug level.");
            this.Info(new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Info level.");
            this.Warn(new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Warn level.");
            this.Error(new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
                "This is the exception log message of Error level.");
            this.Fatal(new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")),
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