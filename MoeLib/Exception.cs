// ***********************************************************************
// Project          : MoeLib
// File             : Exception.cs
// Created          : 2015-03-21  5:13 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-08-11  2:14 PM
// ***********************************************************************
// <copyright file="Exception.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.ObjectModel;
using System.Reflection;
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
        /// <param name="exception">The exception.</param>
        /// <returns>System.String.</returns>
        public static string GetExceptionString(this Exception exception)
        {
            return CreateExceptionString(exception);
        }

        /// <summary>
        ///     Creates the exception string.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <returns>System.String.</returns>
        private static string CreateExceptionString(Exception exception)
        {
            StringBuilder sb = new StringBuilder();
            CreateExceptionString(sb, exception, string.Empty);

            return sb.ToString();
        }

        /// <summary>
        ///     Creates the exception string. If the exception is null.
        ///     The exception string will be String.Empty.
        /// </summary>
        private static void CreateExceptionString(StringBuilder sb, Exception exception, string indent)
        {
            while (true)
            {
                if (exception == null)
                {
                    sb.Append(string.Empty);
                    return;
                }

                if (indent == null)
                {
                    indent = string.Empty;
                }
                else if (indent.Length > 0)
                {
                    sb.AppendFormat("{0}Inner ", indent);
                }

                sb.Append(Environment.NewLine);
                sb.AppendFormat("Exception(s) Found:{0}{1}Type: {2}", Environment.NewLine, indent, exception.GetType().FullName);
                sb.AppendFormat("{0}{1}Message: {2}", Environment.NewLine, indent, exception.Message);
                sb.AppendFormat("{0}{1}Source: {2}", Environment.NewLine, indent, exception.Source);
                sb.AppendFormat("{0}{1}Stacktrace: {2}", Environment.NewLine, indent, exception.StackTrace);

                if (exception is ReflectionTypeLoadException)
                {
                    Exception[] loaderExceptions = ((ReflectionTypeLoadException)exception).LoaderExceptions;
                    if (loaderExceptions == null || loaderExceptions.Length == 0)
                    {
                        sb.AppendFormat("{0}No LoaderExceptions found", indent);
                    }
                    else
                    {
                        foreach (Exception e in loaderExceptions)
                            CreateExceptionString(sb, e, indent + "  ");
                    }
                }
                else if (exception is AggregateException)
                {
                    ReadOnlyCollection<Exception> innerExceptions = ((AggregateException)exception).InnerExceptions;
                    if (innerExceptions == null || innerExceptions.Count == 0)
                        sb.AppendFormat("{0}No InnerExceptions found", indent);
                    else
                    {
                        foreach (Exception e in innerExceptions)
                            CreateExceptionString(sb, e, indent + "  ");
                    }
                }
                else if (exception.InnerException != null)
                {
                    sb.Append(Environment.NewLine);
                    exception = exception.InnerException;
                    indent = indent + "  ";
                    continue;
                }
                break;
            }
        }
    }
}