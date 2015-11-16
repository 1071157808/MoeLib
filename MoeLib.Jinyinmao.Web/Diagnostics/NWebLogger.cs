using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Moe.Lib;
using MoeLib.Diagnostics;

namespace MoeLib.Jinyinmao.Web.Diagnostics
{
    public class NWebLogger : NLogger, IWebLogger
    {
        #region IWebLogger Members

        public void Critical(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(1, message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Fatal(logEntry.ToJson());
        }

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

        public void Error(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(2, message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Error(logEntry.ToJson());
        }

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

        public void Info(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(4, message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Info(logEntry.ToJson());
        }

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

        public void Verbose(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(5, message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Debug(logEntry.ToJson());
        }

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

        public void Warning(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(3, message, request, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Warn(logEntry.ToJson());
        }

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
                    payload.AddIfNotExist("Authorization", request.Headers.Authorization.ToString());
                    payload.AddIfNotExist("Referrer", request.Headers.Referrer.ToString());
                    payload.AddIfNotExist("UserAgent", request.Headers.UserAgent.ToString());

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