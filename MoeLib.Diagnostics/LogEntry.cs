// ***********************************************************************
// Project          : MoeLib
// File             : LogEntry.cs
// Created          : 2015-11-20  5:55 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-24  3:35 PM
// ***********************************************************************
// <copyright file="LogEntry.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;

namespace MoeLib.Diagnostics
{
    /// <summary>
    ///     LogEntry.
    /// </summary>
    public class LogEntry
    {
        /// <summary>
        ///     Gets or sets the deployment identifier.
        /// </summary>
        /// <value>The deployment identifier.</value>
        public string DeploymentId { get; set; }

        /// <summary>
        ///     Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public ulong ErrorCode { get; set; }

        /// <summary>
        ///     Gets or sets the error code MSG.
        /// </summary>
        /// <value>The error code MSG.</value>
        public string ErrorCodeMsg { get; set; }

        /// <summary>
        ///     Gets or sets the event identifier.
        /// </summary>
        /// <value>The event identifier.</value>
        public string EventId { get; set; }

        /// <summary>
        ///     Gets or sets the function.
        /// </summary>
        /// <value>The function.</value>
        public string Function { get; set; }

        /// <summary>
        ///     Gets or sets the level.
        /// </summary>
        /// <value>The level.</value>
        public int Level { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public MessageContent Message { get; set; }

        /// <summary>
        ///     Gets or sets the precise timestamp.
        /// </summary>
        /// <value>The precise timestamp.</value>
        public DateTime PreciseTimeStamp { get; set; }

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
    }
}