using System;
using System.Collections.Generic;
using MoeLib.Diagnostics;
using MoeLib.Orleans;

namespace MoeLib.Jinyinmao.Orleans.Diagnostics
{
    /// <summary>
    ///     Interface IOrleansLogger
    /// </summary>
    public interface IOrleansLogger : ILogger
    {
        /// <summary>
        ///     Logs the message at the <c>Critical</c> level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        void Critical(string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        /// <summary>
        ///     Logs the message at the <c>Error</c> level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        void Error(string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        /// <summary>
        ///     Logs the message at the <c>Info</c> level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        void Info(string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        /// <summary>
        ///     Logs the message at the specified level.
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
        void Log(int level, string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        /// <summary>
        ///     Logs the message at the <c>Verbose</c> level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        void Verbose(string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);

        /// <summary>
        ///     Logs the message at the <c>Warning</c> level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="moeGrainBase">The MoeGrainBase.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        void Warning(string message, MoeGrainBase moeGrainBase, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null);
    }
}