using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Tracing;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     HttpConfigurationExtensions.
    /// </summary>
    public static class HttpConfigurationExtensions
    {
        /// <summary>
        ///     Uses the jinyinmao exception logger.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseJinyinmaoExceptionLogger(this HttpConfiguration config)
        {
            JinyinmaoExceptionLogger logger = new JinyinmaoExceptionLogger();
            config.Services.Add(typeof(IExceptionLogger), logger);
            return config;
        }

        /// <summary>
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