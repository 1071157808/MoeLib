using System;
using System.Collections.Generic;

namespace MoeLib.Diagnostics
{
    public interface ILogger
    {
        void Critical(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Critical(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);

        void Error(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Error(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);

        void Info(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Info(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);

        void Log(int level, string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Log(int level, string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);

        void Verbose(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Verbose(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);

        void Warning(string message, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Warning(string message, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);
    }
}