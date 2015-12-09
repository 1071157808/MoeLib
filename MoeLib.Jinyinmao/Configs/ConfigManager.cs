using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Moe.Lib;
using Moe.Lib.Jinyinmao;

namespace MoeLib.Jinyinmao.Configs
{
    /// <summary>
    ///     ConfigManager.
    /// </summary>
    public class ConfigManager
    {
        private readonly object _lock = new object();
        private readonly IConfigProvider configProvider;
        private bool isConfigRefreshing;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigManager" /> class.
        /// </summary>
        /// <param name="configProvider">The configuration provider.</param>
        internal ConfigManager(IConfigProvider configProvider)
        {
            this.configProvider = configProvider;
            this.RefreshInterval = 5.Minutes();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigManager" /> class.
        /// </summary>
        /// <param name="configProvider">The configuration provider.</param>
        /// <param name="refreshInterval">The refresh interval.</param>
        internal ConfigManager(IConfigProvider configProvider, TimeSpan refreshInterval)
        {
            this.configProvider = configProvider;
            this.RefreshInterval = refreshInterval;
        }

        /// <summary>
        ///     Gets or sets the configuration refresh time.
        /// </summary>
        /// <value>The configuration refresh time.</value>
        public DateTime ConfigRefreshTime { get; protected set; }

        /// <summary>
        ///     Gets or sets the refresh interval.
        /// </summary>
        /// <value>The refresh interval.</value>
        public TimeSpan RefreshInterval { get; }

        private IConfig Config { get; set; }

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <returns>TConfig.</returns>
        public TConfig GetConfig<TConfig>() where TConfig : class, IConfig
        {
            if (!this.GetConfigType().IsSubclassOf(typeof(TConfig)))
            {
                throw new InvalidOperationException($"The config type {typeof(TConfig)} is incorrect.");
            }

            if (this.Config == null)
            {
                this.RefreshConfig<TConfig>();
            }

            if (this.IsConfigNeedRefresh())
            {
                Task.Run(() => this.RefreshConfig<TConfig>());
            }

            return (TConfig)this.Config;
        }

        /// <summary>
        ///     Gets the type of the configuration.
        /// </summary>
        /// <returns>Type.</returns>
        public Type GetConfigType()
        {
            return this.configProvider.GetConfigType();
        }

        /// <summary>
        ///     Gets the configurations string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetConfigurationsString()
        {
            return this.configProvider.GetConfigurationsString();
        }

        /// <summary>
        ///     Gets the get configuration version.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetConfigurationVersion()
        {
            return this.Config == null ? "init" : this.Config.ConfigurationVersion;
        }

        /// <summary>
        ///     Gets the permissions.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, KeyValuePair&lt;System.String, System.String&gt;&gt;.</returns>
        public Dictionary<string, KeyValuePair<string, string>> GetPermissions()
        {
            return this.GetConfig<IConfig>().Permissions;
        }

        /// <summary>
        ///     Gets the resources.
        /// </summary>
        /// <returns>Dictionary&lt;System.String, System.String&gt;.</returns>
        public Dictionary<string, string> GetResources()
        {
            return this.GetConfig<IConfig>().Resources;
        }

        /// <summary>
        ///     Determines whether [is configuration need refresh].
        /// </summary>
        /// <returns><c>true</c> if [is configuration need refresh]; otherwise, <c>false</c>.</returns>
        protected bool IsConfigNeedRefresh()
        {
            return this.ConfigRefreshTime.Add(this.RefreshInterval) < DateTime.UtcNow;
        }

        private void RefreshConfig<TConfig>() where TConfig : class, IConfig
        {
            if (!this.isConfigRefreshing)
            {
                try
                {
                    lock (this._lock)
                    {
                        if (!this.isConfigRefreshing)
                        {
                            this.isConfigRefreshing = true;
                            this.Config = this.configProvider.GetConfigurationsString().FromJson<TConfig>();
                            this.ConfigRefreshTime = DateTime.UtcNow;
                        }
                    }
                }
                catch (Exception e)
                {
                    App.LogManager.CreateLogger().Critical("Can not refresh configurations!", "CONFIGURATIONS ERROR", 0UL, e.Message, null, e,
                        new Dictionary<string, object>
                        {
                            { "SourceVersion", this.GetConfigurationVersion() }
                        });
                }
                finally
                {
                    this.isConfigRefreshing = false;
                }
            }
        }
    }
}