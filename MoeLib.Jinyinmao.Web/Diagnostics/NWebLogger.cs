using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Moe.Lib;
using MoeLib.Diagnostics;

namespace MoeLib.Jinyinmao.Web.Diagnostics
{
    /// <summary>
    ///     NWebLogger.
    /// </summary>
    public class NWebLogger : NLogger, IWebLogger
    {
        #region IWebLogger Members

        /// <summary>
        ///     Criticals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Critical(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(1, message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Fatal(logEntry.ToJson());
        }

        /// <summary>
        ///     Criticals the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
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
        public void Critical(string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Critical(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Error(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(2, message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Error(logEntry.ToJson());
        }

        /// <summary>
        ///     Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
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
        public void Error(string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Error(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Info(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(4, message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Info(logEntry.ToJson());
        }

        /// <summary>
        ///     Informations the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
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
        public void Info(string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Info(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Log(int level, string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            switch (level)
            {
                case 1:
                    this.Critical(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 2:
                    this.Error(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 3:
                    this.Warning(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 4:
                    this.Info(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 5:
                    this.Verbose(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                default:
                    this.Verbose(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;
            }
        }

        /// <summary>
        ///     Logs the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
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
        public void Log(int level, string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            switch (level)
            {
                case 1:
                    this.Critical(message, request, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 2:
                    this.Error(message, request, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 3:
                    this.Warning(message, request, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 4:
                    this.Info(message, request, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                case 5:
                    this.Verbose(message, request, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;

                default:
                    this.Verbose(message, request, clientId, deviceId, requestId, sessionId, userId, tag, errorCode, errorCodeMessage, exception, payload);
                    break;
            }
        }

        /// <summary>
        ///     Verboses the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Verbose(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(5, message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Debug(logEntry.ToJson());
        }

        /// <summary>
        ///     Verboses the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
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
        public void Verbose(string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Verbose(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Warning(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(3, message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Warn(logEntry.ToJson());
        }

        /// <summary>
        ///     Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="request">The request.</param>
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
        public void Warning(string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
        {
            TraceEntry traceEntry = new TraceEntry
            {
                ClientId = clientId,
                DeviceId = deviceId,
                RequestId = requestId,
                SessionId = sessionId,
                UserId = userId
            };

            this.Warning(message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        #endregion IWebLogger Members

        private static LogEntry BuildLogEntry(int level, string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (request != null)
            {
                if (payload == null)
                {
                    payload = new Dictionary<string, object>();
                }

                payload.AddIfNotExist("HttpMethod", request.Method?.Method);

                payload.AddIfNotExist("RequestUri", request.RequestUri?.OriginalString);

                if (request.Headers != null)
                {
                    payload.AddIfNotExist("Authorization", request.Headers.Authorization?.ToString());
                    payload.AddIfNotExist("Referrer", request.Headers.Referrer?.ToString());
                    payload.AddIfNotExist("UserAgent", request.Headers.UserAgent?.ToString());

                    request.Headers.Where(h => h.Key.StartsWith("X-", StringComparison.OrdinalIgnoreCase)).ToList()
                        .ForEach(h => payload.Add(h.Key, h.Value.Join(",")));
                }

                if (request.Content != null)
                {
                    Task<string> contentTask = request.Content.ReadAsStringAsync();
                    contentTask.Wait();
                    payload.AddIfNotExist("Content", contentTask.Result);
                }
            }

            return BuildLogEntry(level, message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }
    }
}