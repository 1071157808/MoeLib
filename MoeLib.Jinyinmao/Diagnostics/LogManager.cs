using Microsoft.WindowsAzure.ServiceRuntime;
using MoeLib.Diagnostics;

namespace MoeLib.Jinyinmao.Diagnostics
{
    /// <summary>
    ///     LogManager.
    /// </summary>
    public class LogManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LogManager" /> class.
        /// </summary>
        internal LogManager()
        {
        }

        /// <summary>
        ///     Creates the logger.
        /// </summary>
        /// <returns>ILogger.</returns>
        public ILogger CreateLogger()
        {
            return this.IsInAzureCloud() ? (ILogger)new WADLogger() : new NLogger();
        }

        /// <summary>
        ///     Determines whether [is in azure cloud].
        /// </summary>
        /// <returns><c>true</c> if [is in azure cloud]; otherwise, <c>false</c>.</returns>
        public bool IsInAzureCloud()
        {
            return RoleEnvironment.IsAvailable;
        }
    }
}