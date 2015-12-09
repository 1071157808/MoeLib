using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using Moe.Lib.Web;
using MoeLib.Jinyinmao.Web.Auth;

namespace MoeLib.Jinyinmao.Web.Filters
{
    /// <summary>
    ///     Class AuthorizationRequiredAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationRequiredAttribute : OrderedAuthorizationFilterAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AuthorizationRequiredAttribute" /> class.
        /// </summary>
        public AuthorizationRequiredAttribute()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Http.Filters.ActionFilterAttribute" /> class.
        /// </summary>
        public AuthorizationRequiredAttribute(string schemeName)
        {
            this.SchemeName = schemeName;
        }

        /// <summary>
        ///     Gets a value indicating whether [require authenticated].
        /// </summary>
        /// <value><c>true</c> if [require authenticated]; otherwise, <c>false</c>.</value>
        public bool RequireAuthenticated { get; set; } = true;

        /// <summary>
        ///     Gets or sets the name of the scheme.
        /// </summary>
        /// <value>The name of the scheme.</value>
        public string SchemeName { get; }

        /// <summary>
        ///     Calls when a process requests authorization.
        /// </summary>
        /// <param name="actionContext">The action context, which encapsulates information for using <see cref="T:System.Web.Http.Filters.AuthorizationFilterAttribute" />.</param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string schemeName = this.SchemeName ?? JYMAuthScheme.Bearer;
            if (actionContext.Request.Headers.Authorization?.Scheme == null || !string.Equals(actionContext.Request.Headers.Authorization.Scheme, schemeName, StringComparison.OrdinalIgnoreCase))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "");
                actionContext.Response.Headers.Add("WWW-Authenticate", $"{this.SchemeName} relam=jinyinmao.com.cn");
                return;
            }

            base.OnAuthorization(actionContext);
        }
    }
}