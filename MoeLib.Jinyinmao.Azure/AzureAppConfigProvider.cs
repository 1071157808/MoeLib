// ***********************************************************************
// Project          : MoeLib
// File             : AzureAppConfigProvider.cs
// Created          : 2015-11-20  5:55 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  12:46 PM
// ***********************************************************************
// <copyright file="AzureAppConfigProvider.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Configuration;
using Microsoft.Azure;
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
        ///     Gets the application keys configuration.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetAppKeysConfig()
        {
            string config = CloudConfigurationManager.GetSetting("AppKeys");
            if (config.IsNullOrEmpty())
            {
                throw new ConfigurationErrorsException("Missing config of \"AppKeys\"");
            }

            return config.HtmlDecode();
        }

        /// <summary>
        ///     Gets the deployment identifier configuration.
        /// </summary>
        /// <returns>Guid.</returns>
        public override Guid GetDeploymentIdConfig()
        {
            return RoleEnvironment.IsAvailable ? RoleEnvironment.DeploymentId.AsGuid() : base.GetDeploymentIdConfig();
        }

        /// <summary>
        ///     Gets the environment.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string GetEnvironment()
        {
            string config = CloudConfigurationManager.GetSetting("Env");
            return config.IsNullOrEmpty() ? "DEV" : config;
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