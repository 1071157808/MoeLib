// ***********************************************************************
// Project          : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  10:49 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-04-19  7:56 PM
// ***********************************************************************
// <copyright file="Crypto.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using Moe.lib;

namespace Moe.Lib
{
    /// <summary>
    ///     Class Crypto.
    /// </summary>
    public class Crypto
    {
        /// <summary>
        ///     Gets the encrypted string.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string PBKDF2(string password, string salt)
        {
            return PBKDF2Utility.Hash(password, salt);
        }

        /// <summary>
        ///     Gets the encrypted string.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string SHA256(string password, string salt)
        {
            return SHA256Utility.Hash(password, salt);
        }
    }
}
