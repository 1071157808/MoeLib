// ***********************************************************************
// Project          : MoeLib
// File             : JinyinmaoController.cs
// Created          : 2015-11-27  12:27 AM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  1:03 AM
// ***********************************************************************
// <copyright file="JinyinmaoController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Net.Http;
using System.Web.Mvc;
using Moe.Lib.Jinyinmao;
using Moe.Lib.Web;
using MoeLib.Diagnostics;
using MoeLib.Jinyinmao.Web;
using MoeLib.Jinyinmao.Web.Diagnostics;

namespace MoeLib.Jinyinmao.Mvc
{
    /// <summary>
    ///     JinyinmaoController.
    /// </summary>
    public class JinyinmaoController : Controller
    {
        private static readonly Lazy<IWebLogger> logger = new Lazy<IWebLogger>(() => InitApplicationLogger());

        private IWebLogger Logger
        {
            get { return logger.Value; }
        }

        protected void Debug(string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Verbose(message, this.Request.AsHttpRequestMessage(), "ASP.NET MVC Log", 0UL, string.Empty, traceEntry);
        }

        protected void Debug(Exception exception)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Verbose(exception.Message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        protected void Debug(Exception exception, string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Verbose(message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        protected void Error(string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Error(message, this.Request.AsHttpRequestMessage(), "ASP.NET MVC Log", 0UL, string.Empty, traceEntry);
        }

        protected void Error(Exception exception)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Error(exception.Message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        protected void Error(Exception exception, string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Error(message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        protected void Fatal(string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Critical(message, this.Request.AsHttpRequestMessage(), "ASP.NET MVC Log", 0UL, string.Empty, traceEntry);
        }

        protected void Fatal(Exception exception)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Critical(exception.Message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        protected void Fatal(Exception exception, string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Critical(message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        protected void Info(string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Info(message, this.Request.AsHttpRequestMessage(), "ASP.NET MVC Log", 0UL, string.Empty, traceEntry);
        }

        protected void Info(Exception exception)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Info(exception.Message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        protected void Info(Exception exception, string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Info(message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        protected void Warn(string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Warning(message, this.Request.AsHttpRequestMessage(), "ASP.NET MVC Log", 0UL, string.Empty, traceEntry);
        }

        protected void Warn(Exception exception)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Warning(exception.Message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        protected void Warn(Exception exception, string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Warning(message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        private static IWebLogger InitApplicationLogger()
        {
            return App.LogManager.CreateWebLogger();
        }
    }
}