// ***********************************************************************
// Project          : MoeLib
// File             : AppOrleansExtensions.cs
// Created          : 2015-11-23  1:40 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  10:10 AM
// ***********************************************************************
// <copyright file="AppOrleansExtensions.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Diagnostics;
using MoeLib.Jinyinmao.Orleans.Diagnostics;

namespace MoeLib.Jinyinmao.Orleans
{
    /// <summary>
    ///     AppOrleansExtensions.
    /// </summary>
    public static class AppOrleansExtensions
    {
        /// <summary>
        ///     Creates the orleans logger.
        /// </summary>
        /// <param name="logManager">The log manager.</param>
        /// <returns>IWebLogger.</returns>
        public static IOrleansLogger CreateOrleansLogger(this LogManager logManager)
        {
            return App.IsAzureMode ? (IOrleansLogger)new WADOrleansLogger() : new NOrleansLogger();
        }
    }
}