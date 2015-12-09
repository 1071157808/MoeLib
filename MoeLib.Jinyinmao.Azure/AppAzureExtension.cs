using Moe.Lib.Jinyinmao;

namespace MoeLib.Jinyinmao.Azure
{
    /// <summary>
    ///     AppAzureExtension.
    /// </summary>
    public static class AppAzureExtension
    {
        /// <summary>
        ///     Configurations for azure.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <returns>App.</returns>
        public static App ConfigForAzure(this App app)
        {
            return app.Config(new AzureAppConfigProvider());
        }
    }
}