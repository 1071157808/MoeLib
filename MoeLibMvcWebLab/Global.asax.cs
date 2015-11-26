// ***********************************************************************
// Project          : MoeLib
// File             : Global.asax.cs
// Created          : 2015-11-26  10:27 AM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  1:14 AM
// ***********************************************************************
// <copyright file="Global.asax.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Azure;

namespace MoeLibMvcWebLab
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            App.Initialize().ConfigWithAzure();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}