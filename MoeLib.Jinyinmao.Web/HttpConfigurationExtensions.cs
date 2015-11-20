using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Tracing;
using MoeLib.Jinyinmao.Web.Diagnostics;
using MoeLib.Jinyinmao.Web.Handlers;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     HttpConfigurationExtensions.
    /// </summary>
    public static class HttpConfigurationExtensions
    {
        /// <summary>
        ///     Uses the jinyinmao configuration.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoConfig(this HttpConfiguration config)
        {
            config.MessageHandlers.Add(new JinyinmaoRequestIdHandler());
            config.MessageHandlers.Add(new JinyinmaoLogHandler());

            config.Services.Replace(typeof(ITraceWriter), new JinyinmaoTraceWriter());
            config.Services.Add(typeof(IExceptionLogger), new JinyinmaoExceptionLogger());

            config.Services.Replace(typeof(IExceptionHandler), new JinyinmaoExceptionHandler());

            return config;
        }

        /// <summary>
        ///     Uses the jinyinmao exception handler.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoExceptionHandler(this HttpConfiguration config)
        {
            config.Services.Replace(typeof(IExceptionHandler), new JinyinmaoExceptionHandler());
            return config;
        }

        /// <summary>
        ///     Uses the jinyinmao exception logger.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoExceptionLogger(this HttpConfiguration config)
        {
            config.Services.Add(typeof(IExceptionLogger), new JinyinmaoExceptionLogger());
            return config;
        }

        /// <summary>
        ///     Uses the jinyinmao logger.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoLogger(this HttpConfiguration config)
        {
            config.Services.Replace(typeof(ITraceWriter), new JinyinmaoTraceWriter());
            config.Services.Add(typeof(IExceptionLogger), new JinyinmaoExceptionLogger());
            return config;
        }

        /// <summary>
        ///     Uses the jinyinmao log handler.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoLogHandler(this HttpConfiguration config)
        {
            config.MessageHandlers.Add(new JinyinmaoLogHandler());
            return config;
        }

        /// <summary>
        ///     Uses the jinyinmao request identifier handler.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoRequestIdHandler(this HttpConfiguration config)
        {
            config.MessageHandlers.Add(new JinyinmaoRequestIdHandler());
            return config;
        }

        /// <summary>
        ///     Uses the jinyinmao trace writer.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoTraceWriter(this HttpConfiguration config)
        {
            config.Services.Replace(typeof(ITraceWriter), new JinyinmaoTraceWriter());
            return config;
        }
    }
}