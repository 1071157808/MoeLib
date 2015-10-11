using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;
using Newtonsoft.Json.Serialization;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     HttpConfigurationExtensions.
    /// </summary>
    public static class HttpConfigurationExtensions
    {
        /// <summary>
        ///     Uses the nlog.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseNLog(this HttpConfiguration config)
        {
            config.Services.Replace(typeof(ITraceWriter), new NLogTraceWriter());
            config.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger());
            return config;
        }

        /// <summary>
        ///     Uses the nlog exception logger.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseNLogExceptionLogger(this HttpConfiguration config, string loggerName = "")
        {
            NLogExceptionLogger logger = loggerName.IsNotNullOrEmpty() ? new NLogExceptionLogger(loggerName) : new NLogExceptionLogger();
            config.Services.Add(typeof(IExceptionLogger), logger);
            return config;
        }

        /// <summary>
        ///     Uses the nlog trace writer.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseNLogTraceWriter(this HttpConfiguration config)
        {
            config.Services.Replace(typeof(ITraceWriter), new NLogTraceWriter());
            return config;
        }

        /// <summary>
        ///     Uses the ordered filter.
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns>HttpConfiguration.</returns>
        public static HttpConfiguration UseOrderedFilter(this HttpConfiguration config)
        {
            config.Services.Replace(typeof(IFilterProvider), new ConfigurationFilterProvider());
            config.Services.Add(typeof(IFilterProvider), new OrderedFilterProvider());
            return config;
        }
    }
}