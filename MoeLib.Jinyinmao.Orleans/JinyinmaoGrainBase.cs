// ***********************************************************************
// Project          : MoeLib
// File             : JinyinmaoGrainBase.cs
// Created          : 2015-11-23  3:46 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  2:11 PM
// ***********************************************************************
// <copyright file="JinyinmaoGrainBase.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Orleans.Diagnostics;
using MoeLib.Orleans;

namespace MoeLib.Jinyinmao.Orleans
{
    /// <summary>
    ///     JinyinmaoGrainBase.
    /// </summary>
    public class JinyinmaoGrainBase : MoeGrainBase, IJinyinmaoGrain
    {
        /// <summary>
        ///     The logger
        /// </summary>
        private readonly Lazy<IOrleansLogger> logger = new Lazy<IOrleansLogger>(() => InitOrleansLogger());

        #region IJinyinmaoGrain Members

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public IOrleansLogger Logger
        {
            get { return this.logger.Value; }
        }

        #endregion IJinyinmaoGrain Members

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <returns>IOrleansLogger.</returns>
        protected new IOrleansLogger GetLogger()
        {
            return this.Logger;
        }

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns>IOrleansLogger.</returns>
        protected new IOrleansLogger GetLogger(string loggerName)
        {
            return this.GetLogger();
        }

        /// <summary>
        ///     Initializes the orleans logger.
        /// </summary>
        /// <returns>IOrleansLogger.</returns>
        private static IOrleansLogger InitOrleansLogger()
        {
            return App.LogManager.CreateOrleansLogger();
        }
    }
}