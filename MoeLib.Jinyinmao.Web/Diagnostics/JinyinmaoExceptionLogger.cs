using System;
using System.Web.Http.ExceptionHandling;
using Moe.Lib.Jinyinmao;
using MoeLib.Diagnostics;

namespace MoeLib.Jinyinmao.Web.Diagnostics
{
    /// <summary>
    ///     JinyinmaoExceptionLogger.
    /// </summary>
    public sealed class JinyinmaoExceptionLogger : ExceptionLogger
    {
        private static readonly Lazy<IWebLogger> logger = new Lazy<IWebLogger>(() => InitApplicationLogger());

        private IWebLogger Logger
        {
            get { return logger.Value; }
        }

        /// <summary>
        ///     When overridden in a derived class, logs the exception synchronously.
        /// </summary>
        /// <param name="context">The exception logger context.</param>
        public override void Log(ExceptionLoggerContext context)
        {
            TraceEntry traceEntry = context.Request?.GetTraceEntry();

            this.Logger.Log(2, context.Exception.Message, context.Request, "ASP.NET Error", 0UL, string.Empty, traceEntry, context.Exception);
        }

        private static IWebLogger InitApplicationLogger()
        {
            return App.LogManager.CreateWebLogger();
        }
    }
}