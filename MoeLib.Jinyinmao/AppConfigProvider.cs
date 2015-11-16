using System;
using System.Configuration;
using Moe.Lib;

namespace MoeLib.Jinyinmao
{
    public class AppConfigProvider : IAppConfigProvider
    {
        #region IAppConfigProvider Members

        public Guid GetDeploymentIdConfig()
        {
            return ConfigurationManager.AppSettings.Get("DeploymentId").AsGuid();
        }

        public string GetPrivateKeyConfig()
        {
            return ConfigurationManager.AppSettings.Get("PrivateKey");
        }

        public string GetRoleConfig()
        {
            return ConfigurationManager.AppSettings.Get("Role");
        }

        public string GetRoleInstanceConfig()
        {
            return ConfigurationManager.AppSettings.Get("RoleInstance");
        }

        #endregion IAppConfigProvider Members
    }
}