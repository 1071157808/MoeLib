using System;
using System.Collections.Generic;
using System.Net.Http;
using MoeLib.Diagnostics;

namespace MoeLib.Jinyinmao.Web.Diagnostics
{
    public interface IWebLogger : ILogger
    {
        void Critical(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Critical(string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);

        void Error(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Error(string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);

        void Info(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Info(string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);

        void Log(int level, string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Log(int level, string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);

        void Verbose(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Verbose(string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);

        void Warning(string message, HttpRequestMessage request, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        void Warning(string message, HttpRequestMessage request, string clientId, string deviceId, string requestId, string sessionId, string userId, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", Exception exception = null, Dictionary<string, object> payload = null);
    }
}