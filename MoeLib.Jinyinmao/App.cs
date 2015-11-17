using System;
using MoeLib.Jinyinmao;

namespace Moe.Lib.Jinyinmao
{
    public class App
    {
        private static readonly App app = new App();

        private Host host;

        private LogManager logManager;

        protected App()
        {
        }

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

        public bool Configurated { get; private set; }
        public bool Initialized { get; private set; }

        public static App Initialize()
        {
            app.host = new Host();
            app.logManager = new LogManager();
            app.Initialized = true;
            return app;
        }

        public App Config(IAppConfigProvider appConfigProvider)
        {
            this.host.DeploymentId = appConfigProvider.GetDeploymentIdConfig();
            this.host.AppKeys = appConfigProvider.GetAppKeysConfig();
            this.host.Role = appConfigProvider.GetRoleConfig();
            this.host.RoleInstance = appConfigProvider.GetRoleInstanceConfig();

            this.Configurated = true;

            return this;
        }

        public App Config()
        {
            return this.Config(new AppConfigProvider());
        }

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