using System;
using System.Configuration;
using Moe.Lib;

namespace MoeLib.Jinyinmao.Configs
{
    /// <summary>
    ///     FileConfigProvider.
    /// </summary>
    /// <typeparam name="TConfig">The type of the configuration.</typeparam>
    public class FileConfigProvider<TConfig> : IConfigProvider where TConfig : class, IConfig
    {
        #region IConfigProvider Members

        /// <summary>
        ///     Gets the type of the configuration.
        /// </summary>
        /// <returns>Type.</returns>
        public Type GetConfigType()
        {
            return typeof(TConfig);
        }

        /// <summary>
        ///     Gets the configurations string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetConfigurationsString()
        {
            string config = ConfigurationManager.AppSettings.Get("Configurations");
            if (config.IsNullOrEmpty())
            {
                throw new ConfigurationErrorsException("Missing config of \"Configurations\"");
            }

            return config;
        }

        #endregion IConfigProvider Members
    }
}