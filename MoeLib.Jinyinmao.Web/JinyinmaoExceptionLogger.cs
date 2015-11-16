using System;
using System.Collections.Generic;
using System.Web.Http.ExceptionHandling;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Web;
using MoeLib.Jinyinmao.Web.Diagnostics;

namespace Moe.Lib.Web
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
            IEnumerable<string> clientId = new List<string>();
            IEnumerable<string> deviceId = new List<string>();
            IEnumerable<string> requestId = new List<string>();
            IEnumerable<string> sessionId = new List<string>();
            IEnumerable<string> userId = new List<string>();

            if (context.Request?.Headers != null)
            {
                context.Request.Headers.TryGetValues("X-JYM-CID", out clientId);
                context.Request.Headers.TryGetValues("X-JYM-DID", out deviceId);
                context.Request.Headers.TryGetValues("X-JYM-RID", out requestId);
                context.Request.Headers.TryGetValues("X-JYM-SID", out sessionId);
                context.Request.Headers.TryGetValues("X-JYM-UID", out userId);
            }

            this.Logger.Log(2, context.Exception.Message, context.Request, clientId.Join(","), deviceId.Join(","),
                requestId.Join(","), sessionId.Join(","), userId.Join(","), "ASP.NET Trace Log", 0UL, string.Empty, context.Exception);
        }

        private static IWebLogger InitApplicationLogger()
        {
            return App.LogManager.CreateWebLogger();
        }
    }
}