// ***********************************************************************
// Project          : MoeLib
// File             : LogController.cs
// Created          : 2015-11-26  10:27 AM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  1:17 AM
// ***********************************************************************
// <copyright file="LogController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Moe.Lib;

namespace MoeLibMvcWebLab.Controllers
{
    public class LogController : ControllerBase
    {
        public ActionResult GetException()
        {
            throw new ApplicationException("This is for testing exception logger",
                new ApplicationException("This is the first inner exception.", new ApplicationException("This is the second inner exception.")));
        }

        public ActionResult GetTrace()
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

            this.ViewBag.Message = "GetTrace";

            return this.View("Log");
        }

        public ActionResult PostException(RequestData request)
        {
            throw new ApplicationException("This is for testing exception logger",
                new ApplicationException("This is the first inner exception.", new ApplicationException("This is the second inner exception.")));
        }

        public ActionResult PostTrace(RequestData request)
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

            this.ViewBag.Message = "PostTrace " + request.ToJson();

            return this.View("Log");
        }

        #region Nested type: RequestData

        public class RequestData
        {
            [Required]
            public Dictionary<string, object> DictionaryData { get; set; }

            [Required]
            public int IntData { get; set; }

            [Required]
            public string StringData { get; set; }
        }

        #endregion Nested type: RequestData
    }
}