using System;
using System.Text;
using System.Web;
using System.Web.Http.ExceptionHandling;
using NLog;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     NLogExceptionLogger.
    /// </summary>
    public sealed class NLogExceptionLogger : ExceptionLogger
    {
        /// <summary>
        ///     The logger
        /// </summary>
        private readonly Logger logger;

        /// <summary>
        ///     Initializes a new instance of the <see cref="NLogExceptionLogger" /> class.
        /// </summary>
        /// <exception cref="NLog.NLogConfigurationException">Can not find ExceptionLogger</exception>
        public NLogExceptionLogger()
        {
            this.logger = LogManager.GetLogger("ExceptionLogger");
            if (this.logger == null)
            {
                throw new NLogConfigurationException("Can not find ExceptionLogger");
            }
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="NLogExceptionLogger" /> class.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <exception cref="NLog.NLogConfigurationException">Can not find ExceptionLogger</exception>
        public NLogExceptionLogger(string loggerName)
        {
            this.logger = LogManager.GetLogger(loggerName);
            if (this.logger == null)
            {
                throw new NLogConfigurationException("Can not find ExceptionLogger");
            }
        }

        /// <summary>
        ///     When overridden in a derived class, logs the exception synchronously.
        /// </summary>
        /// <param name="context">The exception logger context.</param>
        public override void Log(ExceptionLoggerContext context)
        {
            try
            {
                // Retrieve the current HttpContext instance for this request.
                HttpContext httpContext = context.Request.ToHttpContext();

                if (httpContext == null)
                {
                    return;
                }

                string request = httpContext.Request.Dump();

                StringBuilder messageBuilder = new StringBuilder();

                messageBuilder.AppendFormat("{0} {1} {2} {3}", httpContext.Request.HttpMethod, httpContext.Request.RawUrl, httpContext.Response.StatusCode, httpContext.Response.Status);
                messageBuilder.Append(Environment.NewLine);
                messageBuilder.Append(request);
                messageBuilder.Append(Environment.NewLine);
                messageBuilder.Append(context.Exception.GetExceptionString());

                this.logger.Error(messageBuilder.ToString());
            }
            catch (Exception e)
            {
                this.logger.Fatal("NLogExceptionLoggerInternalError" + e);
            }
        }
    }
}