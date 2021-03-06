﻿using System;
using System.Web.Http;

namespace MoeLib.Jinyinmao.Web.Filters
{
    /// <summary>
    ///     ApplicationAuthorizeAttribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ApplicationAuthorizeAttribute : AuthorizeAttribute
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationAuthorizeAttribute" /> class.
        /// </summary>
        public ApplicationAuthorizeAttribute()
        {
            this.Roles = "Application";
        }
    }
}