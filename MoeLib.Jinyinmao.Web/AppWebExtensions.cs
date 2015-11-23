using MoeLib.Jinyinmao.Diagnostics;
using MoeLib.Jinyinmao.Web.Diagnostics;

namespace MoeLib.Jinyinmao.Web
{
    /// <summary>
    ///     AppWebExtensions.
    /// </summary>
    public static class AppWebExtensions
    {
        /// <summary>
        ///     Creates the web logger.
        /// </summary>
        /// <param name="logManager">The log manager.</param>
        /// <returns>IWebLogger.</returns>
        public static IWebLogger CreateWebLogger(this LogManager logManager)
        {
            return logManager.IsInAzureCloud() ? (IWebLogger)new WADWebLogger() : new NWebLogger();
        }
    }
}