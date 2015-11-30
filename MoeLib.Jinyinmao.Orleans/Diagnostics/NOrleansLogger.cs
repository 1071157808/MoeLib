// ***********************************************************************
// Project          : MoeLib
// File             : NOrleansLogger.cs
// Created          : 2015-11-23  5:22 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  2:11 PM
// ***********************************************************************
// <copyright file="NOrleansLogger.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using Moe.Lib;
using MoeLib.Diagnostics;
using MoeLib.Jinyinmao.Diagnostics;
using MoeLib.Orleans;

namespace MoeLib.Jinyinmao.Orleans.Diagnostics
{
    /// <summary>
    ///     NOrleansLogger.
    /// </summary>
    public class NOrleansLogger : NLogger, IOrleansLogger
    {
        #region IOrleansLogger Members

        /// <summary>
        ///     Logs the message at the <c>Critical</c> level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="jinyinmaoGrain"></param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Critical(string message, IJinyinmaoGrain jinyinmaoGrain, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(1, message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Fatal(logEntry.ToJson());
        }

        /// <summary>
        ///     Logs the message at the <c>Error</c> level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="jinyinmaoGrain"></param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Error(string message, IJinyinmaoGrain jinyinmaoGrain, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(2, message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Error(logEntry.ToJson());
        }

        /// <summary>
        ///     Logs the message at the <c>Info</c> level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="jinyinmaoGrain"></param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Info(string message, IJinyinmaoGrain jinyinmaoGrain, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(4, message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Info(logEntry.ToJson());
        }

        /// <summary>
        ///     Logs the message at the specified level.
        /// </summary>
        /// <param name="level">The level.</param>
        /// <param name="message">The message.</param>
        /// <param name="jinyinmaoGrain"></param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Log(int level, string message, IJinyinmaoGrain jinyinmaoGrain, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            switch (level)
            {
                case 1:
                    this.Critical(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 2:
                    this.Error(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 3:
                    this.Warning(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 4:
                    this.Info(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                case 5:
                    this.Verbose(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;

                default:
                    this.Verbose(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
                    break;
            }
        }

        /// <summary>
        ///     Logs the message at the <c>Verbose</c> level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="jinyinmaoGrain"></param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Verbose(string message, IJinyinmaoGrain jinyinmaoGrain, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(5, message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Debug(logEntry.ToJson());
        }

        /// <summary>
        ///     Logs the message at the <c>Warning</c> level.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="jinyinmaoGrain"></param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public void Warning(string message, IJinyinmaoGrain jinyinmaoGrain, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            LogEntry logEntry = BuildLogEntry(3, message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
            this.Logger.Warn(logEntry.ToJson());
        }

        #endregion IOrleansLogger Members

        private static LogEntry BuildLogEntry(int level, string message, IMoeGrain moeGrain, string tag = "None", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (moeGrain != null)
            {
                if (payload == null)
                {
                    payload = new Dictionary<string, object>();
                }

                payload.AddIfNotExist("GrainIdentityString", moeGrain.IdentityString);

                payload.AddIfNotExist("GrainRuntimeIdentity", moeGrain.RuntimeIdentity);
            }

            return BuildLogEntry(level, message, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }
    }
}