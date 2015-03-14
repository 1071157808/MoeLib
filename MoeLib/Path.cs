// ***********************************************************************
// Assembly         : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  10:30 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-14  10:30 PM
// ***********************************************************************
// <copyright file="PathUtils.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

namespace Moe.Lib
{
    /// <summary>
    ///     Utilities methods for working with resource paths
    /// </summary>
    public static class PathUtility
    {
        /// <summary>
        ///     Combines two URL paths
        /// </summary>
        public static string CombinePaths(string path1, string path2)
        {
            if (path2.IsNullOrEmpty())
                return path1;

            if (path1.IsNullOrEmpty())
                return path2;

            if (path2.StartsWith("http://") || path2.StartsWith("https://"))
                return path2;

            char ch = path1[path1.Length - 1];

            if (ch != '/')
                return (path1.TrimEnd('/') + '/' + path2.TrimStart('/'));

            return (path1 + path2);
        }
    }
}
