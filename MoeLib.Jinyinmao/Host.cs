// ***********************************************************************
// Project          : MoeLib
// File             : Host.cs
// Created          : 2015-11-20  5:55 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  12:35 PM
// ***********************************************************************
// <copyright file="Host.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using Microsoft.WindowsAzure.ServiceRuntime;

namespace MoeLib.Jinyinmao
{
    /// <summary>
    ///     Host.
    /// </summary>
    public class Host
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Host" /> class.
        /// </summary>
        internal Host()
        {
        }

        /// <summary>
        ///     Gets or sets the application keys.
        /// </summary>
        /// <value>The application keys.</value>
        public string AppKeys { get; set; }

        /// <summary>
        ///     Gets or sets the deployment identifier.
        /// </summary>
        /// <value>The deployment identifier.</value>
        public Guid DeploymentId { get; set; }

        /// <summary>
        ///     Gets or sets the environment.
        /// </summary>
        /// <value>The environment.</value>
        public string Environment { get; set; }

        /// <summary>
        ///     Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        public string Role { get; set; }

        /// <summary>
        ///     Gets or sets the role instance.
        /// </summary>
        /// <value>The role instance.</value>
        public string RoleInstance { get; set; }

        /// <summary>
        ///     Determines whether the <see cref="Host" /> [is in azure cloud].
        /// </summary>
        /// <returns><c>true</c> if the <see cref="Host" /> [is in azure cloud]; otherwise, <c>false</c>.</returns>
        public bool IsInAzureCloud()
        {
            return RoleEnvironment.IsAvailable;
        }
    }
}