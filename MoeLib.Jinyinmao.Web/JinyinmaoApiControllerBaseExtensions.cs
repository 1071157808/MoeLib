using System;
using System.Net.Http;
using System.Web.Http.Tracing;

namespace MoeLib.Jinyinmao.Web
{
    /// <summary>
    ///     JinyinmaoApiControllerBaseExtensions.
    /// </summary>
    public static class JinyinmaoApiControllerBaseExtensions
    {
        /// <summary>
        ///     Provides a set of methods and properties that help debug your code with the specified writer, request, exception, message format and argument.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="messageFormat">The format of the message.</param>
        /// <param name="messageArguments">The message argument.</param>
        public static void Debug(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, string messageFormat, params object[] messageArguments)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Debug, messageFormat, messageArguments);
        }

        /// <summary>
        ///     Provides a set of methods and properties that help debug your code with the specified writer, request, and exception.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="exception">The error occurred during execution.</param>
        public static void Debug(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, Exception exception)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Debug, exception);
        }

        /// <summary>
        ///     Provides a set of methods and properties that help debug your code with the specified writer, request, exception, message format and argument.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="exception">The error occurred during execution.</param>
        /// <param name="messageFormat">The format of the message.</param>
        /// <param name="messageArguments">The message argument.</param>
        public static void Debug(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, Exception exception, string messageFormat, params object[] messageArguments)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Debug, exception, messageFormat, messageArguments);
        }

        /// <summary>
        ///     Displays an error message in the list with the specified writer, request, message format and argument.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="messageFormat">The format of the message.</param>
        /// <param name="messageArguments">The argument in the message.</param>
        public static void Error(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, string messageFormat, params object[] messageArguments)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Error, messageFormat, messageArguments);
        }

        /// <summary>
        ///     Displays an error message in the list with the specified writer, request, and exception.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="exception">The error occurred during execution.</param>
        public static void Error(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, Exception exception)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Error, exception);
        }

        /// <summary>
        ///     Displays an error message in the list with the specified writer, request, exception, message format and argument.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="messageFormat">The format of the message.</param>
        /// <param name="messageArguments">The argument in the message.</param>
        public static void Error(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, Exception exception, string messageFormat, params object[] messageArguments)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Error, exception, messageFormat, messageArguments);
        }

        /// <summary>
        ///     Displays an error message in the <see cref="T:System.Web.Http.Tracing.TraceWriterExtensions" /> class with the specified writer, request, and message format and argument.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="messageFormat">The format of the message.</param>
        /// <param name="messageArguments">The message argument.</param>
        public static void Fatal(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, string messageFormat, params object[] messageArguments)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Fatal, messageFormat, messageArguments);
        }

        /// <summary>
        ///     Displays an error message in the <see cref="T:System.Web.Http.Tracing.TraceWriterExtensions" /> class with the specified writer, request, and exception.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="exception">The exception that appears during execution.</param>
        public static void Fatal(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, Exception exception)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Fatal, exception);
        }

        /// <summary>
        ///     Displays an error message in the <see cref="T:System.Web.Http.Tracing.TraceWriterExtensions" /> class with the specified writer, request, and exception, message format and argument.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="messageFormat">The format of the message.</param>
        /// <param name="messageArguments">The message argument.</param>
        public static void Fatal(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, Exception exception, string messageFormat, params object[] messageArguments)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Fatal, exception, messageFormat, messageArguments);
        }

        /// <summary>
        ///     Displays the details in the <see cref="System.Web.Http.Tracing.ITraceWriterExtensions" />.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="messageFormat">The format of the message.</param>
        /// <param name="messageArguments">The message argument.</param>
        public static void Info(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, string messageFormat, params object[] messageArguments)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Info, messageFormat, messageArguments);
        }

        /// <summary>
        ///     Displays the details in the <see cref="System.Web.Http.Tracing.ITraceWriterExtensions" />.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="exception">The error occurred during execution.</param>
        public static void Info(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, Exception exception)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Info, exception);
        }

        /// <summary>
        ///     Displays the details in the <see cref="System.Web.Http.Tracing.ITraceWriterExtensions" />.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="exception">The error occurred during execution.</param>
        /// <param name="messageFormat">The format of the message.</param>
        /// <param name="messageArguments">The message argument.</param>
        public static void Info(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, Exception exception, string messageFormat, params object[] messageArguments)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Info, exception, messageFormat, messageArguments);
        }

        /// <summary>
        ///     Indicates the warning level of execution.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="messageFormat">The format of the message.</param>
        /// <param name="messageArguments">The message argument.</param>
        public static void Warn(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, string messageFormat, params object[] messageArguments)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Warn, messageFormat, messageArguments);
        }

        /// <summary>
        ///     Indicates the warning level of execution.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="exception">The error occurred during execution.</param>
        public static void Warn(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, Exception exception)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Warn, exception);
        }

        /// <summary>
        ///     Indicates the warning level of execution.
        /// </summary>
        /// <param name="controller">The <see cref="JinyinmaoApiControllerBase" />.</param>
        /// <param name="request">The <see cref="T:System.Net.Http.HttpRequestMessage" /> with which to associate the trace. It may be null.</param>
        /// <param name="exception">The error occurred during execution.</param>
        /// <param name="messageFormat">The format of the message.</param>
        /// <param name="messageArguments">The message argument.</param>
        public static void Warn(this JinyinmaoApiControllerBase controller, HttpRequestMessage request, Exception exception, string messageFormat, params object[] messageArguments)
        {
            controller.Logger.Trace(request, "Application", TraceLevel.Warn, exception, messageFormat, messageArguments);
        }
    }
}