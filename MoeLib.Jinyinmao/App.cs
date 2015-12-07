// ***********************************************************************
// Project          : MoeLib
// File             : App.cs
// Created          : 2015-11-20  5:55 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  10:11 AM
// ***********************************************************************
// <copyright file="App.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Configuration;
using MoeLib.Jinyinmao;
using MoeLib.Jinyinmao.Configs;
using MoeLib.Jinyinmao.Diagnostics;
using MoeLib.Jinyinmao.Resources;

namespace Moe.Lib.Jinyinmao
{
    /// <summary>
    ///     App.
    /// </summary>
    public class App
    {
        /// <summary>
        ///     The application
        /// </summary>
        private static readonly App app = new App();

        /// <summary>
        ///     The configuration manager
        /// </summary>
        private ConfigManager configManager;

        /// <summary>
        ///     The host
        /// </summary>
        private Host host;

        /// <summary>
        ///     The log manager
        /// </summary>
        private LogManager logManager;

        /// <summary>
        ///     The resource manager
        /// </summary>
        private ResourcesManager resourceManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        private App()
        {
        }

        /// <summary>
        ///     Gets the configuration manager.
        /// </summary>
        /// <value>The configuration manager.</value>
        public static ConfigManager ConfigManager
        {
            get
            {
                if (!app.Initialized || !app.Configurated)
                {
                    ThrowInvalidOperationException();
                }

                if (app.configManager == null)
                {
                    throw new InvalidOperationException("The app has not configurated the ConfigManager.");
                }

                return app.configManager;
            }
        }

        /// <summary>
        ///     Gets the host.
        /// </summary>
        /// <value>The host.</value>
        public static Host Host
        {
            get
            {
                if (!app.Initialized || !app.Configurated)
                {
                    ThrowInvalidOperationException();
                }
                return app.host;
            }
        }

        /// <summary>
        ///     Determines whether the <see cref="App" /> [is in azure cloud].
        /// </summary>
        /// <returns><c>true</c> if the <see cref="App" /> [is in azure cloud]; otherwise, <c>false</c>.</returns>
        public static bool IsInAzureCloud
        {
            get { return app.host.IsInAzureCloud(); }
        }

        /// <summary>
        ///     Gets the log manager.
        /// </summary>
        /// <value>The log manager.</value>
        public static LogManager LogManager
        {
            get
            {
                if (!app.Initialized || !app.Configurated)
                {
                    ThrowInvalidOperationException();
                }
                return app.logManager;
            }
        }

        /// <summary>
        ///     Gets the resource manager.
        /// </summary>
        /// <value>The resource manager.</value>
        /// <exception cref="System.InvalidOperationException">The app has not configurated the ResourceManager.</exception>
        public static ResourcesManager ResourceManager
        {
            get
            {
                if (!app.Initialized || !app.Configurated)
                {
                    ThrowInvalidOperationException();
                }

                if (app.resourceManager == null)
                {
                    throw new InvalidOperationException("The app has not configurated the ResourceManager.");
                }

                return app.resourceManager;
            }
        }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="App" /> is configurated.
        /// </summary>
        /// <value><c>true</c> if configurated; otherwise, <c>false</c>.</value>
        public bool Configurated { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="App" /> is initialized.
        /// </summary>
        /// <value><c>true</c> if initialized; otherwise, <c>false</c>.</value>
        public bool Initialized { get; private set; }

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <typeparam name="TConfig">The type of the t configuration.</typeparam>
        /// <returns>TConfig.</returns>
        public static TConfig GetConfig<TConfig>() where TConfig : class, new()
        {
            ConfigManager<TConfig> manager = ConfigManager as ConfigManager<TConfig>;
            if (manager == null)
            {
                throw new InvalidOperationException($"The config type {typeof(TConfig)} is incorrect.");
            }

            return manager.GetConfig();
        }

        /// <summary>
        ///     Initializes this instance.
        /// </summary>
        /// <returns>App.</returns>
        public static App Initialize()
        {
            app.host = new Host();
            app.logManager = new LogManager();

            app.configManager = null;
            app.resourceManager = null;

            app.Initialized = true;
            return app;
        }

        /// <summary>
        ///     Configurations the specified application configuration provider.
        /// </summary>
        /// <param name="appConfigProvider">The application configuration provider.</param>
        /// <returns>App.</returns>
        public App Config(IAppConfigProvider appConfigProvider)
        {
            this.host.DeploymentId = appConfigProvider.GetDeploymentIdConfig();
            this.host.AppKeys = appConfigProvider.GetAppKeysConfig();
            this.host.Role = appConfigProvider.GetRoleConfig();
            this.host.RoleInstance = appConfigProvider.GetRoleInstanceConfig();

            this.Configurated = true;

            return this;
        }

        /// <summary>
        ///     Configurations this instance.
        /// </summary>
        /// <returns>App.</returns>
        public App Config()
        {
            return this.Config(new AppConfigProvider());
        }

        /// <summary>
        ///     Uses the configuration manager.
        /// </summary>
        /// <typeparam name="TConfig">The type of the configuration.</typeparam>
        /// <param name="configProvider">The configuration provider.</param>
        /// <param name="configProviderForDev">The configuration provider for dev.</param>
        /// <returns>App.</returns>
        public App UseConfigManager<TConfig>(IConfigProvider<TConfig> configProvider, IConfigProvider<TConfig> configProviderForDev = null) where TConfig : class, new()
        {
            if (ConfigurationManager.AppSettings.Get("UseDevConfigProvider").AsBoolean(false) && configProviderForDev != null)
            {
                app.configManager = new ConfigManager<TConfig>(configProviderForDev);
            }

            app.configManager = new ConfigManager<TConfig>(configProvider);

            return app;
        }

        /// <summary>
        ///     Uses the file configuration manager.
        /// </summary>
        /// <typeparam name="TConfig">The type of the configuration.</typeparam>
        /// <param name="configProviderForDev">The configuration provider for dev.</param>
        /// <returns>App.</returns>
        public App UseFileConfigManager<TConfig>(IConfigProvider<TConfig> configProviderForDev = null) where TConfig : class, new()
        {
            return this.UseConfigManager(new FileConfigProvider<TConfig>(), configProviderForDev);
        }

        /// <summary>
        ///     Uses the government server configuration manager.
        /// </summary>
        /// <typeparam name="TConfig">The type of the configuration.</typeparam>
        /// <param name="configProviderForDev">The configuration provider for dev.</param>
        /// <returns>App.</returns>
        public App UseGovernmentServerConfigManager<TConfig>(IConfigProvider<TConfig> configProviderForDev = null) where TConfig : class, new()
        {
            return this.UseConfigManager(new GovernmentServerConfigProvider<TConfig>(), configProviderForDev);
        }

        /// <summary>
        ///     Throws the invalid operation exception.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        ///     The App instance has not been initialized.
        ///     or
        ///     The App instance has not been configurated.
        /// </exception>
        private static void ThrowInvalidOperationException()
        {
            if (!app.Initialized)
            {
                throw new InvalidOperationException("The App instance has not been initialized.");
            }

            if (!app.Configurated)
            {
                throw new InvalidOperationException("The App instance has not been configurated.");
            }
        }
    }
}