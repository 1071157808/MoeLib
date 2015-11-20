using System;
using Microsoft.WindowsAzure.ServiceRuntime;
using Moe.Lib;

namespace MoeLib.Jinyinmao.Azure
{
    /// <summary>
    ///     AzureAppConfigProvider.
    /// </summary>
    public class AzureAppConfigProvider : AppConfigProvider
    {
        /// <summary>
        ///     Gets the deployment identifier configuration.
        /// </summary>
        /// <returns>Guid.</returns>
        public override Guid GetDeploymentIdConfig()
        {
            return RoleEnvironment.IsAvailable ? RoleEnvironment.DeploymentId.AsGuid() : base.GetDeploymentIdConfig();
        }

        /// <summary>
        ///     Gets the role configuration.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetRoleConfig()
        {
            return RoleEnvironment.IsAvailable ? RoleEnvironment.CurrentRoleInstance.Role.Name : base.GetRoleConfig();
        }

        /// <summary>
        ///     Gets the role instance configuration.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetRoleInstanceConfig()
        {
            return RoleEnvironment.IsAvailable ? RoleEnvironment.CurrentRoleInstance.Id : base.GetRoleInstanceConfig();
        }
    }
}