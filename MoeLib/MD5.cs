// ***********************************************************************
// Assembly         : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  1:51 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-14  10:22 PM
// ***********************************************************************
// <copyright file="MD5.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.IO;
using System.Security.Cryptography;

namespace Moe.Lib
{
    public static class MD5Hash
    {
        /// <summary>
        ///     Computes the file hash of the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Hash bytes</returns>
        public static byte[] ComputeHash(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    return md5.ComputeHash(stream);
                }
            }
        }

        /// <summary>
        ///     Computes the file hash of the file.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <returns>Hash string</returns>
        public static string ComputeHashString(string filePath)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filePath))
                {
                    byte[] bytes = md5.ComputeHash(stream);
                    return BitConverter.ToString(bytes).Remove("-").ToLowerInvariant();
                }
            }
        }

        /// <summary>
        ///     Gets the string md5 hash.
        /// </summary>
        /// <param name="stringToHash">The string to hash.</param>
        /// <returns>System.String.</returns>
        public static string ComputeMD5Hash(string stringToHash)
        {
            if (stringToHash == null)
                return "";

            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(stringToHash.GetBytesOfUTF8());
            return data.Hex().ToLowerInvariant();
        }
    }
}
