using System;
using Microsoft.WindowsAzure.ServiceRuntime;
using Moe.Lib;

namespace MoeLib.Jinyinmao.Azure
{
    public class AzureAppConfigProvider : AppConfigProvider
    {
        public override Guid GetDeploymentIdConfig()
        {
            return RoleEnvironment.IsAvailable ? RoleEnvironment.DeploymentId.AsGuid() : base.GetDeploymentIdConfig();
        }

        public override string GetRoleConfig()
        {
            return RoleEnvironment.IsAvailable ? RoleEnvironment.CurrentRoleInstance.Role.Name : base.GetRoleConfig();
        }

        public override string GetRoleInstanceConfig()
        {
            return RoleEnvironment.IsAvailable ? RoleEnvironment.CurrentRoleInstance.Id : base.GetRoleInstanceConfig();
        }
    }
}