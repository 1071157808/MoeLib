using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
using MoeLib.Diagnostics;
using Orleans.Runtime;

namespace MoeLib.Jinyinmao.Web.Diagnostics
{
    /// <summary>
    ///     Asp.Net TraceWriter for Jinyinmao.
    /// </summary>
    public sealed class JinyinmaoSiloTraceWriter : LogWriterBase
    {
        private static readonly Lazy<ILogger> logger = new Lazy<ILogger>(() => InitApplicationLogger());

        private ILogger TraceLogger
        {
            get { return logger.Value; }
        }

        /// <summary>
        ///     The method to call during logging to format the log info into a string ready for output.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="severity">The severity of the message being traced.</param>
        /// <param name="loggerType">The type of logger the message is being traced through.</param>
        /// <param name="caller">The name of the logger tracing the message.</param>
        /// <param name="message">The message to log.</param>
        /// <param name="myIPEndPoint">The <see cref="T:System.Net.IPEndPoint" /> of the Orleans client/server if known. May be null.</param>
        /// <param name="exception">The exception to log. May be null.</param>
        /// <param name="errorCode">Numeric event code for this log entry. May be zero, meaning 'Unspecified'.</param>
        /// <returns>System.String.</returns>
        protected override string FormatLogMessage(DateTime timestamp, Logger.Severity severity, TraceLogger.LoggerType loggerType, string caller, string message, IPEndPoint myIPEndPoint, Exception exception, int errorCode)
        {
            string tag = GetLogTypeTag(loggerType);

            if (errorCode < 0)
            {
                errorCode = -errorCode;
            }

            Dictionary<string, object> payload = new Dictionary<string, object>
            {
                { "IpEndPoint", myIPEndPoint?.ToString() },
                { "SourceSeverity", severity },
                { "SourceTimestamp", timestamp }
            };

            MessageContent messageContent = BuildLogMessageContent(
                $"{caller}: {message}", tag, Convert.ToUInt64(errorCode), string.Empty, null, exception, payload);

            return messageContent.ToJson();
        }

        /// <summary>
        ///     The method to call during logging to write the log message by this log.
        /// </summary>
        /// <param name="msg">Message string to be writter</param>
        /// <param name="severity">The severity level of this message</param>
        protected override void WriteLogMessage(string msg, Logger.Severity severity)
        {
            if (severity == Logger.Severity.Off)
            {
                return;
            }

            MessageContent messageContent = msg.FromJson<MessageContent>();

            this.TraceLogger.Log(GetLogLevel(severity), messageContent.Message, messageContent.Tag, messageContent.ErrorCode, messageContent.ErrorCodeMsg,
                null, null, messageContent.Payload);
        }

        private static MessageContent BuildLogMessageContent(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.AppendLine(message);

            if (exception != null)
            {
                messageBuilder.AppendLine(exception.GetExceptionString());
            }

            MessageContent messageContent = new MessageContent
            {
                ClientId = traceEntry == null ? string.Empty : traceEntry.ClientId,
                DeviceId = traceEntry == null ? string.Empty : traceEntry.DeviceId,
                ErrorCode = errorCode,
                ErrorCodeMsg = errorCodeMessage,
                Message = messageBuilder.ToString(),
                Payload = payload ?? new Dictionary<string, object>(),
                RequestId = traceEntry == null ? string.Empty : traceEntry.DeviceId,
                SessionId = traceEntry == null ? string.Empty : traceEntry.DeviceId,
                Tag = tag,
                UserId = traceEntry == null ? string.Empty : traceEntry.DeviceId
            };
            return messageContent;
        }

        private static int GetLogLevel(Logger.Severity severity)
        {
            switch (severity)
            {
                case Logger.Severity.Error:
                    return 2;

                case Logger.Severity.Warning:
                    return 3;

                case Logger.Severity.Info:
                    return 4;

                default:
                    return 5;
            }
        }

        private static string GetLogTypeTag(TraceLogger.LoggerType loggerType)
        {
            switch (loggerType)
            {
                case global::Orleans.Runtime.TraceLogger.LoggerType.Grain:
                    return "Orleans Grain Trace Log";

                case global::Orleans.Runtime.TraceLogger.LoggerType.Application:
                    return "Orleans Application Trace Log";

                case global::Orleans.Runtime.TraceLogger.LoggerType.Provider:
                    return "Orleans Provider Trace Log";

                case global::Orleans.Runtime.TraceLogger.LoggerType.Runtime:
                    return "Orleans Runtime Trace Log";

                default:
                    return "Orleans Trace Log";
            }
        }

        private static ILogger InitApplicationLogger()
        {
            return App.LogManager.CreateLogger();
        }
    }
}