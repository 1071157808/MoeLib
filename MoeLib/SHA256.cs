// ***********************************************************************
// Assembly         : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  10:48 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-14  10:54 PM
// ***********************************************************************
// <copyright file="SHA256.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Security.Cryptography;
using System.Text;

namespace Moe.Lib
{
    /// <summary>
    ///     Class SHA256Utility.
    /// </summary>
    public static class SHA256Utility
    {
        /// <summary>
        ///     Hashes the specified password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string Hash(string password, string salt)
        {
            string stringToHash = password + salt;
            SHA256 sha256 = SHA256.Create();
            byte[] hashBytes = sha256.ComputeHash(stringToHash.GetBytesOfUTF8());
            StringBuilder hashString = new StringBuilder();
            foreach (byte b in hashBytes)
                hashString.Append(b.ToString("x2"));
            return hashString.ToString();
        }
    }
}
