using System;
using System.Configuration;
using Moe.Lib;

namespace MoeLib.Jinyinmao
{
    public class AppConfigProvider : IAppConfigProvider
    {
        #region IAppConfigProvider Members

        public virtual string GetAppKeysConfig()
        {
            return ConfigurationManager.AppSettings.Get("AppKeys").HtmlDecode();
        }

        public virtual Guid GetDeploymentIdConfig()
        {
            return Guid.NewGuid();
        }

        public virtual string GetRoleConfig()
        {
            return ConfigurationManager.AppSettings.Get("Role");
        }

        public virtual string GetRoleInstanceConfig()
        {
            return ConfigurationManager.AppSettings.Get("Role") + "_" + HostServer.IP;
        }

        #endregion IAppConfigProvider Members
    }
}