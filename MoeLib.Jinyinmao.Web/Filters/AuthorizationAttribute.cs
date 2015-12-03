using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MoeLib.Jinyinmao.Web.Filters
{
    /// <summary>
    ///     Class AuthorizationAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationAttribute : ActionFilterAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Http.Filters.ActionFilterAttribute" /> class.
        /// </summary>
        public AuthorizationAttribute(string schemeName)
        {
            this.SchemeName = schemeName;
        }

        /// <summary>
        ///     Gets or sets the name of the scheme.
        /// </summary>
        /// <value>The name of the scheme.</value>
        public string SchemeName { get; }

        /// <summary>
        ///     Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!string.Equals(actionContext.Request.Headers.Authorization.Scheme, this.SchemeName, StringComparison.OrdinalIgnoreCase))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "");
                actionContext.Response.Headers.Add("WWW-Authenticate", $"{this.SchemeName} relam=jinyinmao.com.cn");
            }
            base.OnActionExecuting(actionContext);
        }
    }
}