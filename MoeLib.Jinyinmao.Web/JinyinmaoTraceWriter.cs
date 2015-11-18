using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http.Tracing;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Web;
using MoeLib.Jinyinmao.Web.Diagnostics;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     Asp.Net TraceWriter for Jinyinmao.
    /// </summary>
    public sealed class JinyinmaoTraceWriter : ITraceWriter
    {
        private static readonly Lazy<IWebLogger> logger = new Lazy<IWebLogger>(() => InitApplicationLogger());

        private IWebLogger Logger
        {
            get { return logger.Value; }
        }

        #region ITraceWriter Members

        /// <summary>
        ///     The loggers
        /// </summary>
        /// <summary>
        ///     Gets the current logger.
        /// </summary>
        /// <value>The current logger.</value>
        /// <summary>
        ///     Invokes the specified traceAction to allow setting values in a new <see cref="T:System.Web.Http.Tracing.TraceRecord" /> if and only if tracing is permitted at the given category and level.
        /// </summary>
        /// <param name="request">The current <see cref="T:System.Net.Http.HttpRequestMessage" />.   It may be null but doing so will prevent subsequent trace analysis  from correlating the trace to a particular request.</param>
        /// <param name="category">The logical category for the trace.  Users can define their own.</param>
        /// <param name="level">The <see cref="T:System.Web.Http.Tracing.TraceLevel" /> at which to write this trace.</param>
        /// <param name="traceAction">The action to invoke if tracing is enabled.  The caller is expected to fill in the fields of the given <see cref="T:System.Web.Http.Tracing.TraceRecord" /> in this action.</param>
        public void Trace(HttpRequestMessage request, string category, TraceLevel level, Action<TraceRecord> traceAction)
        {
            if (level == TraceLevel.Off) return;

            TraceRecord record = new TraceRecord(request, category, level);

            traceAction(record);
            this.LogTraceRecord(record);
        }

        #endregion ITraceWriter Members

        private static int GetLogLevel(TraceLevel traceLevel)
        {
            switch (traceLevel)
            {
                case TraceLevel.Fatal:
                    return 1;

                case TraceLevel.Error:
                    return 2;

                case TraceLevel.Warn:
                    return 3;

                case TraceLevel.Info:
                    return 4;

                case TraceLevel.Debug:
                    return 5;

                default:
                    return 5;
            }
        }

        private static IWebLogger InitApplicationLogger()
        {
            return App.LogManager.CreateWebLogger();
        }

        /// <summary>
        ///     Logs the trace record.
        /// </summary>
        /// <param name="traceRecord">The trace record.</param>
        private void LogTraceRecord(TraceRecord traceRecord)
        {
            IEnumerable<string> clientId = null;
            IEnumerable<string> deviceId = null;
            IEnumerable<string> requestId = null;
            IEnumerable<string> sessionId = null;
            IEnumerable<string> userId = null;

            if (traceRecord.Request?.Headers != null)
            {
                traceRecord.Request.Headers.TryGetValues("X-JYM-CID", out clientId);
                traceRecord.Request.Headers.TryGetValues("X-JYM-DID", out deviceId);
                traceRecord.Request.Headers.TryGetValues("X-JYM-RID", out requestId);
                traceRecord.Request.Headers.TryGetValues("X-JYM-SID", out sessionId);
                traceRecord.Request.Headers.TryGetValues("X-JYM-UID", out userId);
            }

            this.Logger.Log(GetLogLevel(traceRecord.Level), traceRecord.Message, traceRecord.Request, clientId?.Join(","), deviceId?.Join(","),
                requestId?.Join(","), sessionId?.Join(","), userId?.Join(","), "ASP.NET Trace Log", 0UL, string.Empty, traceRecord.Exception);
        }
    }
}