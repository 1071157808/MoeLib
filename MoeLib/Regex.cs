// ***********************************************************************
// Assembly         : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  10:17 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-21  6:58 PM
// ***********************************************************************
// <copyright file="Regex.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Text.RegularExpressions;

namespace Moe.Lib
{
    /// <summary>
    ///     RegexUtility.
    /// </summary>
    public static class RegexUtility
    {
        /// <summary>
        ///     A regular expression for validating cellphone number.
        /// </summary>
        public static readonly Regex CellphoneRegex = new Regex(@"^(13|14|15|17|18)\d{9}$");

        /// <summary>
        ///     A regular expression for validating Email Addresses. Taken from http://net.tutsplus.com/tutorials/other/8-regular-expressions-you-should-know/
        /// </summary>
        public static readonly Regex EmailRegex = new Regex(@"^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$");

        /// <summary>
        ///     A regular expression for validating IPAddresses. Taken from http://net.tutsplus.com/tutorials/other/8-regular-expressions-you-should-know/
        /// </summary>
        public static readonly Regex IPAddressRegex = new Regex(@"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$");

        /// <summary>
        ///     A regular expression for validating that string is a positive number GREATER THAN zero.
        /// </summary>
        public static readonly Regex PositiveNumberRegex = new Regex(@"^[1-9]+[0-9]*$");

        /// <summary>
        ///     A regular expression for validating absolute Urls. Taken from http://net.tutsplus.com/tutorials/other/8-regular-expressions-you-should-know/
        /// </summary>
        public static readonly Regex UrlRegex = new Regex(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w \.-]*)*\/?$");
    }
}
