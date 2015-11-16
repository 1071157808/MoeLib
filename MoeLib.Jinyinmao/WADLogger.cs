using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Moe.Lib;
using MoeLib.Diagnostics;

namespace MoeLib.Jinyinmao
{
    public class WADLogger : ILogger
    {
        #region ILogger Members

        public void Critical(string message, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            MessageContent logMessageContent = BuildLogMessageContent(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            Trace.TraceError(logMessageContent.ToJson());
        }

        public void Critical(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Critical(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        public void Error(string message, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            MessageContent logMessageContent = BuildLogMessageContent(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            Trace.TraceError(logMessageContent.ToJson());
        }

        public void Error(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Error(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        public void Info(string message, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            MessageContent logMessageContent = BuildLogMessageContent(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            Trace.TraceInformation(logMessageContent.ToJson());
        }

        public void Info(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Info(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        public void Log(int level, string message, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            switch (level)
            {
                case 1:
                    this.Critical(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 2:
                    this.Error(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 3:
                    this.Warning(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 4:
                    this.Info(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 5:
                    this.Verbose(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                default:
                    this.Verbose(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;
            }
        }

        public void Log(int level, string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            switch (level)
            {
                case 1:
                    this.Critical(message, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 2:
                    this.Error(message, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 3:
                    this.Warning(message, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 4:
                    this.Info(message, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 5:
                    this.Verbose(message, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                default:
                    this.Verbose(message, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;
            }
        }

        public void Verbose(string message, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
        }

        public void Verbose(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Verbose(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        public void Warning(string message, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            MessageContent logMessageContent = BuildLogMessageContent(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            Trace.TraceWarning(logMessageContent.ToJson());
        }

        public void Warning(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Warning(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        #endregion ILogger Members

        protected static MessageContent BuildLogMessageContent(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
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
    }
}