using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Tracing;
using NLog;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     Asp.Net TraceWriter with NLog.
    /// </summary>
    public sealed class NLogTraceWriter : ITraceWriter
    {
        /// <summary>
        ///     The loggers
        /// </summary>
        private static readonly Lazy<Dictionary<TraceLevel, Action<string>>> Loggers =
            new Lazy<Dictionary<TraceLevel, Action<string>>>(() =>
                new Dictionary<TraceLevel, Action<string>>
                {
                    { TraceLevel.Debug, LogManager.GetLogger("TraceLogger").Debug },
                    { TraceLevel.Info, LogManager.GetLogger("TraceLogger").Info },
                    { TraceLevel.Error, LogManager.GetLogger("TraceLogger").Error },
                    { TraceLevel.Warn, LogManager.GetLogger("TraceLogger").Warn },
                    { TraceLevel.Fatal, LogManager.GetLogger("TraceLogger").Fatal }
                }
                );

        /// <summary>
        ///     Gets the current logger.
        /// </summary>
        /// <value>The current logger.</value>
        private static Dictionary<TraceLevel, Action<string>> CurrentLogger
        {
            get { return Loggers.Value; }
        }

        #region ITraceWriter Members

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
#pragma warning disable 4014
            LogToNlogAsync(record);
#pragma warning restore 4014
        }

        #endregion ITraceWriter Members

        /// <summary>
        ///     Logs to nlog.
        /// </summary>
        /// <param name="traceRecord">The trace record.</param>
        private static async Task LogToNlogAsync(TraceRecord traceRecord)
        {
            StringBuilder messageBuilder = new StringBuilder();

            messageBuilder.Append(traceRecord.Timestamp.ToChinaStandardTime().ToString("O"));

            if (traceRecord.Request != null)
            {
                if (traceRecord.Request.Method != null)
                {
                    messageBuilder.Append(traceRecord.Request.Method);
                }
                else
                {
                    messageBuilder.Append("   -");
                }

                if (traceRecord.Request.RequestUri != null)
                {
                    messageBuilder.Append("   " + traceRecord.Request.RequestUri);
                }
                else
                {
                    messageBuilder.Append("   -");
                }

                string content = await traceRecord.Request.Content.ReadAsStringAsync();
                messageBuilder.Append(content.IsNotNullOrEmpty() ? content : "   -");
            }

            messageBuilder.Append(traceRecord.Message.IsNotNullOrWhiteSpace() ? traceRecord.Message : "   -");

            if (traceRecord.Exception != null)
            {
                messageBuilder.Append(traceRecord.Request.Dump());
                messageBuilder.AppendLine();
                messageBuilder.Append(traceRecord.Exception.GetExceptionString());
            }

            CurrentLogger[traceRecord.Level](messageBuilder.ToString());
        }
    }
}