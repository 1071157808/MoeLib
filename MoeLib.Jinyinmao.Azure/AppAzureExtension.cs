using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Config;

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

        /// <summary>
        ///     Uses the azure configuration manager.
        /// </summary>
        /// <typeparam name="TConfig">The type of the t configuration.</typeparam>
        /// <param name="app">The application.</param>
        /// <param name="configProviderForDev">The configuration provider for dev.</param>
        /// <returns>App.</returns>
        public static App UseAzureConfigManager<TConfig>(this App app, IConfigProvider<TConfig> configProviderForDev = null) where TConfig : class, new()
        {
            return app.UseConfigManager(new AzureConfigProvider<TConfig>(), configProviderForDev);
        }
    }
}