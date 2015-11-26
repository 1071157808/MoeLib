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
using MoeLib.Jinyinmao.Web.Diagnostics;

namespace MoeLib.Jinyinmao.Web
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

        /// <summary>
        ///     Provides a set of methods and properties that help debug your code with the specified writer, request, exception, message format and argument.
        /// </summary>
        /// <param name="message">The log message.</param>
        protected void Debug(string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Verbose(message, this.Request.AsHttpRequestMessage(), "ASP.NET MVC Log", 0UL, string.Empty, traceEntry);
        }

        /// <summary>
        ///     Provides a set of methods and properties that help debug your code with the specified writer, request, and exception.
        /// </summary>
        /// <param name="exception">The error occurred during execution.</param>
        protected void Debug(Exception exception)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Verbose(exception.Message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        /// <summary>
        ///     Provides a set of methods and properties that help debug your code with the specified writer, request, exception, message format and argument.
        /// </summary>
        /// <param name="exception">The error occurred during execution.</param>
        /// <param name="message">The log message.</param>
        protected void Debug(Exception exception, string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Verbose(message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        /// <summary>
        ///     Displays an error message in the list with the specified writer, request, message format and argument.
        /// </summary>
        /// <param name="message">The log message.</param>
        protected void Error(string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Error(message, this.Request.AsHttpRequestMessage(), "ASP.NET MVC Log", 0UL, string.Empty, traceEntry);
        }

        /// <summary>
        ///     Displays an error message in the list with the specified writer, request, and exception.
        /// </summary>
        /// <param name="exception">The error occurred during execution.</param>
        protected void Error(Exception exception)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Error(exception.Message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        /// <summary>
        ///     Displays an error message in the list with the specified writer, request, exception, message format and argument.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The log message.</param>
        protected void Error(Exception exception, string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Error(message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        /// <summary>
        ///     Displays an error message in the <see cref="T:System.Web.Http.Tracing.TraceWriterExtensions" /> class with the specified writer, request, and message format and argument.
        /// </summary>
        /// <param name="message">The log message.</param>
        protected void Fatal(string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Critical(message, this.Request.AsHttpRequestMessage(), "ASP.NET MVC Log", 0UL, string.Empty, traceEntry);
        }

        /// <summary>
        ///     Displays an error message in the <see cref="T:System.Web.Http.Tracing.TraceWriterExtensions" /> class with the specified writer, request, and exception.
        /// </summary>
        /// <param name="exception">The exception that appears during execution.</param>
        protected void Fatal(Exception exception)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Critical(exception.Message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        /// <summary>
        ///     Displays an error message in the <see cref="T:System.Web.Http.Tracing.TraceWriterExtensions" /> class with the specified writer, request, and exception, message format and argument.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="message">The log message.</param>
        protected void Fatal(Exception exception, string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Critical(message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        /// <summary>
        ///     Displays the details in the <see cref="System.Web.Http.Tracing.ITraceWriterExtensions" />.
        /// </summary>
        /// <param name="message">The log message.</param>
        protected void Info(string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Info(message, this.Request.AsHttpRequestMessage(), "ASP.NET MVC Log", 0UL, string.Empty, traceEntry);
        }

        /// <summary>
        ///     Displays the details in the <see cref="System.Web.Http.Tracing.ITraceWriterExtensions" />.
        /// </summary>
        /// <param name="exception">The error occurred during execution.</param>
        protected void Info(Exception exception)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Info(exception.Message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        /// <summary>
        ///     Displays the details in the <see cref="System.Web.Http.Tracing.ITraceWriterExtensions" />.
        /// </summary>
        /// <param name="exception">The error occurred during execution.</param>
        /// <param name="message">The log message.</param>
        protected void Info(Exception exception, string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Info(message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        /// <summary>
        ///     Indicates the warning level of execution.
        /// </summary>
        /// <param name="message">The log message.</param>
        protected void Warn(string message)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Warning(message, this.Request.AsHttpRequestMessage(), "ASP.NET MVC Log", 0UL, string.Empty, traceEntry);
        }

        /// <summary>
        ///     Indicates the warning level of execution.
        /// </summary>
        /// <param name="exception">The error occurred during execution.</param>
        protected void Warn(Exception exception)
        {
            HttpRequestMessage request = this.Request?.AsHttpRequestMessage();
            TraceEntry traceEntry = request?.GetTraceEntry();

            this.Logger.Warning(exception.Message, request, "ASP.NET MVC Log", 0UL, string.Empty, traceEntry, exception);
        }

        /// <summary>
        ///     Indicates the warning level of execution.
        /// </summary>
        /// <param name="exception">The error occurred during execution.</param>
        /// <param name="message">The log message.</param>
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