using System;
using System.Collections.Generic;
using MoeLib.Diagnostics;
using Orleans.Runtime;

namespace MoeLib.Jinyinmao.Orleans
{
    /// <summary>
    ///     JinyinmaoGrainBaseExtensions.
    /// </summary>
    public static class JinyinmaoGrainBaseExtensions
    {
        /// <summary>
        ///     Logs the message at the <c>Critical</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrainBase">The jinyinmaoGrainBase.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public static void Critical(this JinyinmaoGrainBase jinyinmaoGrainBase, string message, string tag = "Orleans Grain Log", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (traceEntry == null)
            {
                traceEntry = RequestContext.Get("TraceEntry") as TraceEntry;
            }

            jinyinmaoGrainBase.Logger.Critical(message, jinyinmaoGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the message at the <c>Critical</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrainBase">The jinyinmaoGrainBase.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Critical(this JinyinmaoGrainBase jinyinmaoGrainBase, string message, Exception exception)
        {
            jinyinmaoGrainBase.Critical(message, "Orleans Grain Log", 0UL, "", null, exception);
        }

        /// <summary>
        ///     Logs the message at the <c>Error</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrainBase">The jinyinmaoGrainBase.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public static void Error(this JinyinmaoGrainBase jinyinmaoGrainBase, string message, string tag = "Orleans Grain Log", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (traceEntry == null)
            {
                traceEntry = RequestContext.Get("TraceEntry") as TraceEntry;
            }

            jinyinmaoGrainBase.Logger.Error(message, jinyinmaoGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the message at the <c>Error</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrainBase">The jinyinmaoGrainBase.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Error(this JinyinmaoGrainBase jinyinmaoGrainBase, string message, Exception exception)
        {
            jinyinmaoGrainBase.Critical(message, "Orleans Grain Log", 0UL, "", null, exception);
        }

        /// <summary>
        ///     Logs the message at the <c>Info</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrainBase">The jinyinmaoGrainBase.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public static void Info(this JinyinmaoGrainBase jinyinmaoGrainBase, string message, string tag = "Orleans Grain Log", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (traceEntry == null)
            {
                traceEntry = RequestContext.Get("TraceEntry") as TraceEntry;
            }

            jinyinmaoGrainBase.Logger.Info(message, jinyinmaoGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the message at the <c>Info</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrainBase">The jinyinmaoGrainBase.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Info(this JinyinmaoGrainBase jinyinmaoGrainBase, string message, Exception exception)
        {
            jinyinmaoGrainBase.Critical(message, "Orleans Grain Log", 0UL, "", null, exception);
        }

        /// <summary>
        ///     Logs the message at the <c>Verbose</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrainBase">The jinyinmaoGrainBase.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public static void Verbose(this JinyinmaoGrainBase jinyinmaoGrainBase, string message, string tag = "Orleans Grain Log", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (traceEntry == null)
            {
                traceEntry = RequestContext.Get("TraceEntry") as TraceEntry;
            }

            jinyinmaoGrainBase.Logger.Verbose(message, jinyinmaoGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the message at the <c>Verbose</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrainBase">The jinyinmaoGrainBase.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Verbose(this JinyinmaoGrainBase jinyinmaoGrainBase, string message, Exception exception)
        {
            jinyinmaoGrainBase.Critical(message, "Orleans Grain Log", 0UL, "", null, exception);
        }

        /// <summary>
        ///     Logs the message at the <c>Warning</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrainBase">The jinyinmaoGrainBase.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public static void Warning(this JinyinmaoGrainBase jinyinmaoGrainBase, string message, string tag = "Orleans Grain Log", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (traceEntry == null)
            {
                traceEntry = RequestContext.Get("TraceEntry") as TraceEntry;
            }

            jinyinmaoGrainBase.Logger.Warning(message, jinyinmaoGrainBase, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the message at the <c>Warning</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrainBase">The jinyinmaoGrainBase.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Warning(this JinyinmaoGrainBase jinyinmaoGrainBase, string message, Exception exception)
        {
            jinyinmaoGrainBase.Critical(message, "Orleans Grain Log", 0UL, "", null, exception);
        }
    }
}