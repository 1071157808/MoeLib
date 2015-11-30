// ***********************************************************************
// Project          : MoeLib
// File             : JinyinmaoGrainBaseExtensions.cs
// Created          : 2015-11-23  3:21 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  2:11 PM
// ***********************************************************************
// <copyright file="JinyinmaoGrainBaseExtensions.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using MoeLib.Diagnostics;
using Orleans.Runtime;

namespace MoeLib.Jinyinmao.Orleans
{
    /// <summary>
    ///     JinyinmaoGrainExtensions.
    /// </summary>
    public static class JinyinmaoGrainExtensions
    {
        /// <summary>
        ///     Logs the message at the <c>Critical</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrain">The jinyinmaoGrain.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public static void Critical(this IJinyinmaoGrain jinyinmaoGrain, string message, string tag = "Orleans Grain Log", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (traceEntry == null)
            {
                traceEntry = RequestContext.Get("TraceEntry") as TraceEntry;
            }

            jinyinmaoGrain.Logger.Critical(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the message at the <c>Critical</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrain">The jinyinmaoGrain.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Critical(this IJinyinmaoGrain jinyinmaoGrain, string message, Exception exception)
        {
            jinyinmaoGrain.Critical(message, "Orleans Grain Log", 0UL, "", null, exception);
        }

        /// <summary>
        ///     Logs the message at the <c>Error</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrain">The jinyinmaoGrain.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public static void Error(this IJinyinmaoGrain jinyinmaoGrain, string message, string tag = "Orleans Grain Log", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (traceEntry == null)
            {
                traceEntry = RequestContext.Get("TraceEntry") as TraceEntry;
            }

            jinyinmaoGrain.Logger.Error(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the message at the <c>Error</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrain">The jinyinmaoGrain.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Error(this IJinyinmaoGrain jinyinmaoGrain, string message, Exception exception)
        {
            jinyinmaoGrain.Critical(message, "Orleans Grain Log", 0UL, "", null, exception);
        }

        /// <summary>
        ///     Logs the message at the <c>Info</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrain">The jinyinmaoGrain.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public static void Info(this IJinyinmaoGrain jinyinmaoGrain, string message, string tag = "Orleans Grain Log", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (traceEntry == null)
            {
                traceEntry = RequestContext.Get("TraceEntry") as TraceEntry;
            }

            jinyinmaoGrain.Logger.Info(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the message at the <c>Info</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrain">The jinyinmaoGrain.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Info(this IJinyinmaoGrain jinyinmaoGrain, string message, Exception exception)
        {
            jinyinmaoGrain.Critical(message, "Orleans Grain Log", 0UL, "", null, exception);
        }

        /// <summary>
        ///     Logs the message at the <c>Verbose</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrain">The jinyinmaoGrain.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public static void Verbose(this IJinyinmaoGrain jinyinmaoGrain, string message, string tag = "Orleans Grain Log", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (traceEntry == null)
            {
                traceEntry = RequestContext.Get("TraceEntry") as TraceEntry;
            }

            jinyinmaoGrain.Logger.Verbose(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the message at the <c>Verbose</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrain">The jinyinmaoGrain.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Verbose(this IJinyinmaoGrain jinyinmaoGrain, string message, Exception exception)
        {
            jinyinmaoGrain.Critical(message, "Orleans Grain Log", 0UL, "", null, exception);
        }

        /// <summary>
        ///     Logs the message at the <c>Warning</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrain">The jinyinmaoGrain.</param>
        /// <param name="message">The message.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="errorCodeMessage">The error code message.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="payload">The payload.</param>
        public static void Warning(this IJinyinmaoGrain jinyinmaoGrain, string message, string tag = "Orleans Grain Log", ulong errorCode = 0UL, string errorCodeMessage = "", TraceEntry traceEntry = null, Exception exception = null, Dictionary<string, object> payload = null)
        {
            if (traceEntry == null)
            {
                traceEntry = RequestContext.Get("TraceEntry") as TraceEntry;
            }

            jinyinmaoGrain.Logger.Warning(message, jinyinmaoGrain, tag, errorCode, errorCodeMessage, traceEntry, exception, payload);
        }

        /// <summary>
        ///     Logs the message at the <c>Warning</c> level.
        /// </summary>
        /// <param name="jinyinmaoGrain">The jinyinmaoGrain.</param>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        public static void Warning(this IJinyinmaoGrain jinyinmaoGrain, string message, Exception exception)
        {
            jinyinmaoGrain.Critical(message, "Orleans Grain Log", 0UL, "", null, exception);
        }
    }
}