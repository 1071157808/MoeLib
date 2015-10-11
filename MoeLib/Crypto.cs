// ***********************************************************************
// Project          : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  10:49 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-04-19  8:59 PM
// ***********************************************************************
// <copyright file="Crypto.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

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
        /// <param name="payload">The payload.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string PBKDF2(string payload, string salt)
        {
            return PBKDF2Utility.Hash(payload, salt);
        }

        /// <summary>
        ///     Gets the encrypted string.
        /// </summary>
        /// <param name="payload">The payload.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string SHA256(string payload, string salt)
        {
            return SHA256Utility.Hash(payload, salt);
        }
    }
}