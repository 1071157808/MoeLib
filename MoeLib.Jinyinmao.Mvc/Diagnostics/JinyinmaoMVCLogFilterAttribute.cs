// ***********************************************************************
// Project          : MoeLib
// File             : JinyinmaoMVCLogFilterAttribute.cs
// Created          : 2015-11-26  11:15 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  1:30 AM
// ***********************************************************************
// <copyright file="JinyinmaoMVCLogFilterAttribute.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
using Moe.Lib.Web;
using MoeLib.Diagnostics;
using MoeLib.Jinyinmao.Web;
using MoeLib.Jinyinmao.Web.Diagnostics;

namespace MoeLib.Jinyinmao.Mvc.Diagnostics
{
    /// <summary>
    ///     JinyinmaoMVCLogFilterAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class JinyinmaoMVCLogFilterAttribute : ActionFilterAttribute
    {
        /// <summary>
        ///     The logger
        /// </summary>
        private static readonly Lazy<IWebLogger> logger = new Lazy<IWebLogger>(() => InitApplicationLogger());

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        private IWebLogger Logger
        {
            get { return logger.Value; }
        }

        /// <summary>
        ///     Called by the ASP.NET MVC framework before the action method executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpRequestMessage request = filterContext.HttpContext.Request.AsHttpRequestMessage();
            if (request != null)
            {
                TraceEntry traceEntry = request.GetTraceEntry();

                string requestIdString = traceEntry?.RequestId;
                if (requestIdString.IsNullOrEmpty())
                {
                    requestIdString = Guid.NewGuid().ToGuidString();
                    filterContext.HttpContext.Request.Headers.Add("X-JYM-RID", requestIdString);
                }

                this.Logger.Info($"Request Begin: {requestIdString}", request, "ASP.NET MVC Request", 0UL, string.Empty, traceEntry);
            }

            base.OnActionExecuting(filterContext);
        }

        /// <summary>
        ///     Called by the ASP.NET MVC framework after the action result executes.
        /// </summary>
        /// <param name="filterContext">The filter context.</param>
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            HttpRequestMessage request = filterContext.HttpContext.Request.AsHttpRequestMessage();
            HttpResponseBase response = filterContext.HttpContext.Response;

            if (request != null && response != null)
            {
                TraceEntry traceEntry = request.GetTraceEntry();

                Dictionary<string, object> payload = new Dictionary<string, object>
                {
                    { "ResponseStatusCode", response.StatusCode }
                };

                this.Logger.Info($"Request End: {traceEntry.RequestId}", request, "ASP.NET MVC Response", 0UL, string.Empty, traceEntry, null, payload);
            }

            base.OnResultExecuted(filterContext);
        }

        private static IWebLogger InitApplicationLogger()
        {
            return App.LogManager.CreateWebLogger();
        }
    }
}