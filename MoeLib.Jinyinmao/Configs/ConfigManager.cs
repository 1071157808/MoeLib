using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Moe.Lib;

namespace MoeLib.Jinyinmao.Configs
{
    /// <summary>
    ///     ConfigManager.
    /// </summary>
    public class ConfigManager<TConfig> : ConfigManager, IConfigProvider<TConfig> where TConfig : class, new()
    {
        private readonly object _lock = new object();
        private readonly IConfigProvider<TConfig> configProvider;
        private bool isConfigRefreshing;

        internal ConfigManager(IConfigProvider<TConfig> configProvider)
        {
            this.configProvider = configProvider;
        }

        internal ConfigManager(IConfigProvider<TConfig> configProvider, TimeSpan refreshInterval) : base(refreshInterval)
        {
            this.configProvider = configProvider;
        }

        private TConfig Config { get; set; }

        #region IConfigProvider<TConfig> Members

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <returns>TConfig.</returns>
        public TConfig GetConfig()
        {
            if (this.Config == null)
            {
                this.RefreshConfig();
            }

            if (this.IsConfigNeedRefresh())
            {
                Task.Run(() => this.RefreshConfig());
            }

            return this.Config;
        }

        /// <summary>
        ///     Gets the configuration json string.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetConfigJsonString()
        {
            return this.configProvider.GetConfigJsonString();
        }

        /// <summary>
        ///     Gets the type of the configuration.
        /// </summary>
        /// <returns>Type.</returns>
        public Type GetConfigType()
        {
            return this.configProvider.GetConfigType();
        }

        #endregion IConfigProvider<TConfig> Members

        private void RefreshConfig()
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
                            this.Config = this.configProvider.GetConfig();
                            this.ConfigRefreshTime = DateTime.UtcNow;
                        }
                    }
                }
                finally
                {
                    this.isConfigRefreshing = false;
                }
            }
        }
    }

    /// <summary>
    ///     ConfigManager.
    /// </summary>
    public class ConfigManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigManager" /> class.
        /// </summary>
        protected ConfigManager()
        {
            this.RefreshInterval = 5.Minutes();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConfigManager" /> class.
        /// </summary>
        /// <param name="refreshInterval">The refresh interval.</param>
        protected ConfigManager(TimeSpan refreshInterval)
        {
            this.RefreshInterval = refreshInterval;
        }

        /// <summary>
        ///     Gets or sets the configuration refresh time.
        /// </summary>
        /// <value>The configuration refresh time.</value>
        [SuppressMessage("ReSharper", "MemberCanBeProtected.Global")]
        public DateTime ConfigRefreshTime { get; protected set; }

        /// <summary>
        ///     Gets or sets the refresh interval.
        /// </summary>
        /// <value>The refresh interval.</value>
        public TimeSpan RefreshInterval { get; }

        /// <summary>
        ///     Determines whether [is configuration need refresh].
        /// </summary>
        /// <returns><c>true</c> if [is configuration need refresh]; otherwise, <c>false</c>.</returns>
        protected bool IsConfigNeedRefresh()
        {
            return this.ConfigRefreshTime.Add(this.RefreshInterval) < DateTime.UtcNow;
        }
    }
}