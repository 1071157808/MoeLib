using System;
using System.Collections.Generic;
using System.Text;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
using MoeLib.Diagnostics;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;
using ILogger = MoeLib.Diagnostics.ILogger;

namespace MoeLib.Jinyinmao
{
    public class NLogger : ILogger
    {
        private static readonly Lazy<NLog.ILogger> ApplicationLogger = new Lazy<NLog.ILogger>(() => InitApplicationLogger());

        static NLogger()
        {
            LoggingConfiguration config = new LoggingConfiguration();

            FileTarget target = new FileTarget
            {
                AutoFlush = true,
                CreateDirs = true,
                Encoding = Encoding.UTF8,
                FileName = Layout.FromString(AppDomain.CurrentDomain.BaseDirectory + "Logs\\${shortdate}.log"),
                Layout = Layout.FromString("${message}")
            };

            config.AddTarget("ApplicationTarget", target);

            config.LoggingRules.Add(new LoggingRule("ApplicationLogger", LogLevel.Info, target));

            NLog.LogManager.Configuration = config;
        }

        protected NLog.ILogger Logger
        {
            get { return ApplicationLogger.Value; }
        }

        #region ILogger Members

        public void Critical(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(1, message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Fatal(logEntry.ToJson());
        }

        public void Critical(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
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

        public void Error(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(2, message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Error(logEntry.ToJson());
        }

        public void Error(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
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

        public void Info(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(4, message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Info(logEntry.ToJson());
        }

        public void Info(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
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

        public void Verbose(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(5, message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Debug(logEntry.ToJson());
        }

        public void Verbose(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
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

        public void Warning(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(3, message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Warn(logEntry.ToJson());
        }

        public void Warning(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null)
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

        protected static LogEntry BuildLogEntry(int level, string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            StringBuilder messageBuilder = new StringBuilder();
            messageBuilder.AppendLine(message);

            if (exception != null)
            {
                messageBuilder.AppendLine(exception.GetExceptionString());
            }

            LogEntry logEntry = new LogEntry
            {
                DeploymentId = App.Host.DeploymentId.ToGuidString(),
                ErrorCode = errorCode,
                ErrorCodeMsg = errorCodeMessage,
                EventId = level.ToString(),
                Function = string.Empty,
                Level = level,
                PreciseTimeStamp = DateTime.UtcNow,
                Role = App.Host.Role,
                RoleInstance = App.Host.RoleInstance,
                Message = new MessageContent
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
                }
            };
            return logEntry;
        }

        private static NLog.ILogger InitApplicationLogger()
        {
            return NLog.LogManager.GetLogger("ApplicationLogger");
        }
    }
}