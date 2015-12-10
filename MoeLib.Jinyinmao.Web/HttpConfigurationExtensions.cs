using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Tracing;
using MoeLib.Jinyinmao.Web.Diagnostics;
using MoeLib.Jinyinmao.Web.Handlers;
using MoeLib.Jinyinmao.Web.Handlers.Server;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     HttpConfigurationExtensions.
    /// </summary>
    public static class HttpConfigurationExtensions
    {
        /// <summary>
        ///     Uses the jinyinmao authorization handler.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="bearerAuthKeys">The bearer keys.</param>
        /// <param name="governmentServerPublicKey">The government server public key.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoAuthorizationHandler(this HttpConfiguration config, string bearerAuthKeys, string governmentServerPublicKey)
        {
            config.MessageHandlers.Add(new JinyinmaoAuthorizationHandler(bearerAuthKeys, governmentServerPublicKey));
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
        ///     Uses the jinyinmao log handler.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="requestTag">The request tag.</param>
        /// <param name="responseTag">The response tag.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoLogHandler(this HttpConfiguration config, string requestTag, string responseTag)
        {
            config.MessageHandlers.Add(new JinyinmaoLogHandler(requestTag, responseTag));
            return config;
        }

        /// <summary>
        ///     Uses the jinyinmao trace entry handler.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoTraceEntryHandler(this HttpConfiguration config)
        {
            config.MessageHandlers.Add(new JinyinmaoTraceEntryHandler());
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