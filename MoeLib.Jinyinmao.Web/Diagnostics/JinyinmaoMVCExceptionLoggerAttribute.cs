// ***********************************************************************
// Project          : MoeLib
// File             : JinyinmaoMVCExceptionLoggerAttribute.cs
// Created          : 2015-11-27  12:01 AM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  12:20 AM
// ***********************************************************************
// <copyright file="JinyinmaoMVCExceptionLoggerAttribute.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Net.Http;
using System.Web.Mvc;
using Moe.Lib.Jinyinmao;
using Moe.Lib.Web;
using MoeLib.Diagnostics;

namespace MoeLib.Jinyinmao.Web.Diagnostics
{
    /// <summary>
    ///     JinyinmaoMVCExceptionLoggerAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class JinyinmaoMVCExceptionLoggerAttribute : FilterAttribute, IExceptionFilter
    {
        private static readonly Lazy<IWebLogger> logger = new Lazy<IWebLogger>(() => InitApplicationLogger());

        private IWebLogger Logger
        {
            get { return logger.Value; }
        }

        #region IExceptionFilter Members

        /// <summary>
        ///     Called when an exception occurs.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public void OnException(ExceptionContext filterContext)
        {
            HttpRequestMessage request = filterContext.HttpContext?.Request?.AsHttpRequestMessage();
            if (request != null)
            {
                TraceEntry traceEntry = request.GetTraceEntry();

                this.Logger.Log(2, filterContext.Exception.Message, request, "ASP.NET MVC Error", 0UL, string.Empty, traceEntry, filterContext.Exception);
            }
        }

        #endregion IExceptionFilter Members

        private static IWebLogger InitApplicationLogger()
        {
            return App.LogManager.CreateWebLogger();
        }
    }
}