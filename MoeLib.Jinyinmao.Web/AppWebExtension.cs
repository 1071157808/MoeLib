using MoeLib.Jinyinmao.Web.Diagnostics;

namespace MoeLib.Jinyinmao.Web
{
    public static class AppWebExtension
    {
        public static IWebLogger CreateWebLogger(this LogManager logManager)
        {
            return logManager.IsInAzureCloud() ? (IWebLogger)new WADWebLogger() : new NWebLogger();
        }
    }
}