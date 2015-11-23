using MoeLib.Jinyinmao.Diagnostics;
using MoeLib.Jinyinmao.Orleans.Diagnostics;

namespace MoeLib.Jinyinmao.Orleans
{
    /// <summary>
    ///     AppOrleansExtensions.
    /// </summary>
    public static class AppOrleansExtensions
    {
        /// <summary>
        ///     Creates the orleans logger.
        /// </summary>
        /// <param name="logManager">The log manager.</param>
        /// <returns>IWebLogger.</returns>
        public static IOrleansLogger CreateOrleansLogger(this LogManager logManager)
        {
            return logManager.IsInAzureCloud() ? (IOrleansLogger)new WADOrleansLogger() : new NOrleansLogger();
        }
    }
}