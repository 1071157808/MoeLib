using System;
using System.Net.Http;
using System.Web.Http.Tracing;
using Moe.Lib.Jinyinmao;
using MoeLib.Diagnostics;

namespace MoeLib.Jinyinmao.Web.Diagnostics
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
            if (level == TraceLevel.Off || category != "Application") return;

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
            TraceEntry traceEntry = traceRecord.Request?.GetTraceEntry();

            this.Logger.Log(GetLogLevel(traceRecord.Level), traceRecord.Message, traceRecord.Request, "ASP.NET Trace", 0UL, string.Empty, traceEntry, traceRecord.Exception);
        }
    }
}