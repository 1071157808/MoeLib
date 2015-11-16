using Microsoft.WindowsAzure.ServiceRuntime;
using MoeLib.Diagnostics;

namespace MoeLib.Jinyinmao
{
    public class LogManager
    {
        internal LogManager()
        {
        }

        public ILogger CreateLogger()
        {
            return this.IsInAzureCloud() ? (ILogger)new WADLogger() : new NLogger();
        }

        public bool IsInAzureCloud()
        {
            return RoleEnvironment.IsAvailable;
        }
    }
}