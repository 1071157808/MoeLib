using System;
using Microsoft.Azure;
using Microsoft.WindowsAzure.ServiceRuntime;
using Moe.Lib;

namespace MoeLib.Jinyinmao.Azure
{
    public class AzureAppConfigProvider : IAppConfigProvider
    {
        #region IAppConfigProvider Members

        public Guid GetDeploymentIdConfig()
        {
            return RoleEnvironment.IsAvailable ? RoleEnvironment.DeploymentId.AsGuid() : CloudConfigurationManager.GetSetting("DeploymentId").AsGuid();
        }

        public string GetPrivateKeyConfig()
        {
            return CloudConfigurationManager.GetSetting("PrivateKey");
        }

        public string GetRoleConfig()
        {
            return RoleEnvironment.IsAvailable ? RoleEnvironment.CurrentRoleInstance.Role.Name : CloudConfigurationManager.GetSetting("Role");
        }

        public string GetRoleInstanceConfig()
        {
            return RoleEnvironment.IsAvailable ? RoleEnvironment.CurrentRoleInstance.Id : CloudConfigurationManager.GetSetting("RoleInstance");
        }

        #endregion IAppConfigProvider Members
    }
}