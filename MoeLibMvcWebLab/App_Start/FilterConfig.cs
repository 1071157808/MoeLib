// ***********************************************************************
// Project          : MoeLib
// File             : FilterConfig.cs
// Created          : 2015-11-26  10:27 AM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  1:03 AM
// ***********************************************************************
// <copyright file="FilterConfig.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Web.Mvc;
using MoeLib.Jinyinmao.Web.Diagnostics;

namespace MoeLibMvcWebLab
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new JinyinmaoMVCLogFilterAttribute());
            filters.Add(new JinyinmaoMVCExceptionLoggerAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}