using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace MoeLib.Jinyinmao.Web.Filters
{
    /// <summary>
    ///     Class HeaderFileterAttribute.
    /// </summary>
    public class HeaderFileterAttribute : ActionFilterAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="T:System.Web.Http.Filters.ActionFilterAttribute" /> class.
        /// </summary>
        public HeaderFileterAttribute(string schemeName)
        {
            this.SchemeName = schemeName;
        }

        public string SchemeName { get; set; }

        /// <summary>
        ///     Occurs before the action method is invoked.
        /// </summary>
        /// <param name="actionContext">The action context.</param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization.Scheme != this.SchemeName
                && this.CheckParameter(actionContext.Request.Headers.Authorization.Parameter))
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, " ");
                actionContext.Response.Headers.Add("WWW-Authenticate", "Basic relam=jinyinmao.com.cn");
                return;
            }
            base.OnActionExecuting(actionContext);
        }

        /// <summary>
        /// Checks the parameter.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        private bool CheckParameter(string context)
        {
            List<string> list = context.Split(':').ToList();
            if (list.Count == 0)
            {
                return false;
            }
            switch (this.SchemeName)
            {
                case "Basic":
                case "JYMWeChat":
                    return list.Count == 2;

                case "JYMQuick":
                    return list.Count == 1;
            }
            return false;
        }
    }
}