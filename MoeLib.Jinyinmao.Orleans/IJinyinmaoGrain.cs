// ***********************************************************************
// Project          : MoeLib
// File             : IJinyinmaoGrain.cs
// Created          : 2015-11-25  2:02 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  2:03 PM
// ***********************************************************************
// <copyright file="IJinyinmaoGrain.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using MoeLib.Jinyinmao.Orleans.Diagnostics;
using MoeLib.Orleans;

namespace MoeLib.Jinyinmao.Orleans
{
    /// <summary>
    ///     Interface IJinyinmaoGrainBase
    /// </summary>
    public interface IJinyinmaoGrain : IMoeGrain
    {
        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        IOrleansLogger Logger { get; }
    }
}