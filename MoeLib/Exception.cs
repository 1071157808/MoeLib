// ***********************************************************************
// Assembly         : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-21  5:13 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-21  6:50 PM
// ***********************************************************************
// <copyright file="Exception.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Text;

namespace Moe.Lib
{
    /// <summary>
    ///     Extensions of <see cref="System.Exception" /> type.
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        ///     Gets the exception string.
        /// </summary>
        /// <param name="e">The e.</param>
        /// <returns>System.String.</returns>
        public static string GetExceptionString(this Exception e)
        {
            return CreateExceptionString(e);
        }

        /// <summary>
        ///     Creates the exception string.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <returns>System.String.</returns>
        private static string CreateExceptionString(Exception e)
        {
            StringBuilder sb = new StringBuilder();
            CreateExceptionString(sb, e, string.Empty);

            return sb.ToString();
        }

        /// <summary>
        ///     Creates the exception string.
        /// </summary>
        /// <param name="sb">The string builder.</param>
        /// <param name="e">The exception.</param>
        /// <param name="indent">The indent string.</param>
        private static void CreateExceptionString(StringBuilder sb, Exception e, string indent)
        {
            if (indent == null)
            {
                indent = string.Empty;
            }
            else if (indent.Length > 0)
            {
                sb.AppendFormat("{0}Inner ", indent);
            }

            sb.AppendFormat("Exception Found:\r\n{0}Type: {1}", indent, e.GetType().FullName);
            sb.AppendFormat("\r\n{0}Message: {1}", indent, e.Message);
            sb.AppendFormat("\r\n{0}Source: {1}", indent, e.Source);
            sb.AppendFormat("\r\n{0}Stacktrace: {1}", indent, e.StackTrace);

            if (e.InnerException != null)
            {
                sb.Append("\r\n");
                CreateExceptionString(sb, e.InnerException, indent + "  ");
            }
        }
    }
}
