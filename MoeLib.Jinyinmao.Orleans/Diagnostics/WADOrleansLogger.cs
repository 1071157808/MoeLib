using System;
using System.Collections.Generic;
using System.Diagnostics;
using Moe.Lib;
using MoeLib.Diagnostics;
using MoeLib.Jinyinmao.Diagnostics;
using MoeLib.Orleans;

namespace MoeLib.Jinyinmao.Orleans.Diagnostics
{
    /// <summary>
    ///     WADOrleansLogger.
    /// </summary>
    public class WADOrleansLogger : WADLogger, IOrleansLogger
    {
        #region IOrleansLogger Members

        /// <summary>
        ///     Criticals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Critical(string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            MessageContent logMessageContent = BuildLogMessageContent(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            Trace.TraceError(logMessageContent.ToJson());
        }

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Error(string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            MessageContent logMessageContent = BuildLogMessageContent(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            Trace.TraceError(logMessageContent.ToJson());
        }

        /// <summary>
        ///     Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Info(string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            MessageContent logMessageContent = BuildLogMessageContent(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            Trace.TraceInformation(logMessageContent.ToJson());
        }

        /// <summary>
        ///     Logs the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Log(int level, string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            switch (level)
            {
                case 1:
                    this.Critical(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 2:
                    this.Error(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 3:
                    this.Warning(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 4:
                    this.Info(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 5:
                    this.Verbose(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                default:
                    this.Verbose(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;
            }
        }

        /// <summary>
        ///     Verboses the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Verbose(string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
        }

        /// <summary>
        ///     Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Warning(string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            MessageContent logMessageContent = BuildLogMessageContent(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            Trace.TraceWarning(logMessageContent.ToJson());
        }

        #endregion IOrleansLogger Members

        /// <summary>
        ///     Criticals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Critical(string message, MoeGrainBase moeGrainBase, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Critical(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Error(string message, MoeGrainBase moeGrainBase, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Error(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Info(string message, MoeGrainBase moeGrainBase, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Info(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Log(int level, string message, MoeGrainBase moeGrainBase, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            switch (level)
            {
                case 1:
                    this.Critical(message, moeGrainBase, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 2:
                    this.Error(message, moeGrainBase, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 3:
                    this.Warning(message, moeGrainBase, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 4:
                    this.Info(message, moeGrainBase, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 5:
                    this.Verbose(message, moeGrainBase, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                default:
                    this.Verbose(message, moeGrainBase, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;
            }
        }

        /// <summary>
        ///     Verboses the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Verbose(string message, MoeGrainBase moeGrainBase, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Verbose(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="clientId">The client identifier.</param>
        /// <param name="deviceId">The device identifier.</param>
        /// <param name="requestId">The request identifier.</param>
        /// <param name="sessionId">The session identifier.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Warning(string message, MoeGrainBase moeGrainBase, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Warning(message, moeGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        private static MessageContent BuildLogMessageContent(string message, MoeGrainBase moeGrainBase, string tag, ulong errorCode, string errorCodeMessage, TraceEntry traceEntry, Exception exception, Dictionary<string, object> payload)
        {
            if (moeGrainBase != null)
            {
                if (payload == null)
                {
                    payload = new Dictionary<string, object>();
                }

                payload.AddIfNotExist("GrainIdentityString", moeGrainBase.IdentityString);

                payload.AddIfNotExist("GrainRuntimeIdentity", moeGrainBase.RuntimeIdentity);
            }

            return BuildLogMessageContent(message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }
    }
}