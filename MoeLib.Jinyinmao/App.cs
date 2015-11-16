using System;
using MoeLib.Diagnostics;
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
            return app;
        }

        public App Config(IAppConfigProvider appConfigProvider)
        {
            Host.DeploymentId = appConfigProvider.GetDeploymentIdConfig();
            Host.PrivateKey = appConfigProvider.GetPrivateKeyConfig();
            Host.Role = appConfigProvider.GetRoleConfig();
            Host.RoleInstance = appConfigProvider.GetRoleInstanceConfig();

            return this;
        }

        public App Config()
        {
            return this.Config(new AppConfigProvider());
        }

        public ILogger GetLogger()
        {
            return LogManager.CreateLogger();
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