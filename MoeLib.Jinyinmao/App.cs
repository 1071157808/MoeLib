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
using MoeLib.Jinyinmao;
using MoeLib.Jinyinmao.Diagnostics;

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
        ///     The host
        /// </summary>
        private Host host;

        /// <summary>
        ///     The log manager
        /// </summary>
        private LogManager logManager;

        /// <summary>
        ///     Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        private App()
        {
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
        ///     Initializes this instance.
        /// </summary>
        /// <returns>App.</returns>
        public static App Initialize()
        {
            app.host = new Host();
            app.logManager = new LogManager();
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