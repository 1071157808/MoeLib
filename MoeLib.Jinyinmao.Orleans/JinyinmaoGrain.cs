// ***********************************************************************
// Project          : MoeLib
// File             : JinyinmaoGrain.cs
// Created          : 2015-11-25  1:48 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  2:11 PM
// ***********************************************************************
// <copyright file="JinyinmaoGrain.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using MoeLib.Jinyinmao.Orleans.Diagnostics;
using MoeLib.Orleans;
using Orleans;

namespace MoeLib.Jinyinmao.Orleans
{
    /// <summary>
    ///     JinyinmaoGrain.
    /// </summary>
    public class JinyinmaoGrain : MoeGrain, IJinyinmaoGrain
    {
        private readonly IJinyinmaoGrain jinyinmaoGrainBase = new JinyinmaoGrainBase();

        #region IJinyinmaoGrain Members

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public IOrleansLogger Logger
        {
            get { return this.jinyinmaoGrainBase.Logger; }
        }

        #endregion IJinyinmaoGrain Members
    }

    /// <summary>
    ///     JinyinmaoGrain.
    /// </summary>
    public class JinyinmaoGrain<TGrainState> : MoeGrain<TGrainState>, IJinyinmaoGrain where TGrainState : GrainState
    {
        private readonly IJinyinmaoGrain jinyinmaoGrainBase = new JinyinmaoGrainBase();

        #region IJinyinmaoGrain Members

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public IOrleansLogger Logger
        {
            get { return this.jinyinmaoGrainBase.Logger; }
        }

        #endregion IJinyinmaoGrain Members
    }
}