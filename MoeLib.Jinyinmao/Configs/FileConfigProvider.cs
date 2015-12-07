using System;
using System.Configuration;
using Moe.Lib;

namespace MoeLib.Jinyinmao.Configs
{
    /// <summary>
    ///     FileConfigProvider.
    /// </summary>
    /// <typeparam name="TConfig">The type of the configuration.</typeparam>
    public class FileConfigProvider<TConfig> : IConfigProvider<TConfig> where TConfig : class, new()
    {
        #region IConfigProvider<TConfig> Members

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <returns>TConfig.</returns>
        public TConfig GetConfig()
        {
            return this.GetConfigJsonString().FromJson<TConfig>();
        }

        /// <summary>
        ///     Gets the configuration json string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetConfigJsonString()
        {
            string config = ConfigurationManager.AppSettings.Get("Configs");
            if (config.IsNullOrEmpty())
            {
                throw new ConfigurationErrorsException("Missing config of \"Configs\"");
            }

            return config;
        }

        /// <summary>
        ///     Gets the type of the configuration.
        /// </summary>
        /// <returns>Type.</returns>
        public Type GetConfigType()
        {
            return typeof(TConfig);
        }

        #endregion IConfigProvider<TConfig> Members
    }
}