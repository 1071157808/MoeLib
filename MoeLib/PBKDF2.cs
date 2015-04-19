// ***********************************************************************
// Project          : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  10:41 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-04-19  7:49 PM
// ***********************************************************************
// <copyright file="PBKDF2.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Security.Cryptography;
using System.Text;
using Moe.Lib;

namespace Moe.lib
{
    // Come from FluentSharp
    // Code based on example from: Password Minder Internals http://msdn.microsoft.com/en-us/magazine/cc163913.aspx
    // implementation of PKCS#5 v2.0
    // Password Based Key Derivation Function 2
    // http://www.rsasecurity.com/rsalabs/pkcs/pkcs-5/index.html
    // For the HMAC function, see RFC 2104
    // http://www.ietf.org/rfc/rfc2104.txt

    /// <summary>
    ///     Class PBKDF2Utility.
    /// </summary>
    public class PBKDF2Utility
    {
        // SHA-256 has a 512-bit block size and gives a 256-bit output
        /// <summary>
        ///     The block size in bytes
        /// </summary>
        private const int BlockSizeInBytes = 64;

        /// <summary>
        ///     The default PBKD f2 bytes
        /// </summary>
        private const int DefaultPBKDF2Bytes = 64;

        /// <summary>
        ///     The default PBKD f2 interactions
        /// </summary>
        private const int DefaultPBKDF2Interactions = 100; // 20000;

        /// <summary>
        ///     The hash size in bytes
        /// </summary>
        private const int HashSizeInBytes = 32;

        /// <summary>
        ///     The ipad
        /// </summary>
        private const byte Ipad = 0x36;

        /// <summary>
        ///     The opad
        /// </summary>
        private const byte Opad = 0x5C;

        /// <summary>
        ///     Gets the bytes.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The iterations.</param>
        /// <param name="howManyBytes">The how many bytes.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytes(string password, byte[] salt, int iterations, int howManyBytes)
        {
            return GetBytes(
                Encoding.UTF8.GetBytes(password),
                salt, iterations, howManyBytes);
        }

        /// <summary>
        ///     Gets the bytes.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The iterations.</param>
        /// <param name="howManyBytes">The how many bytes.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytes(byte[] password, byte[] salt, int iterations, int howManyBytes)
        {
            // round up

            uint cBlocks = (uint)((howManyBytes + HashSizeInBytes - 1) / HashSizeInBytes);

            // seed for the pseudo-random fcn: salt + block index
            byte[] saltAndIndex = new byte[salt.Length + 4];
            Array.Copy(salt, 0, saltAndIndex, 0, salt.Length);

            byte[] output = new byte[cBlocks * HashSizeInBytes];
            int outputOffset = 0;

            SHA256Managed innerHash = new SHA256Managed();
            SHA256Managed outerHash = new SHA256Managed();

            // HMAC says the key must be hashed or padded with zeros
            // so it fits into a single block of the hash in use
            if (password.Length > BlockSizeInBytes)
            {
                password = innerHash.ComputeHash(password);
            }
            byte[] key = new byte[BlockSizeInBytes];
            Array.Copy(password, 0, key, 0, password.Length);

            byte[] innerKey = new byte[BlockSizeInBytes];
            byte[] outerKey = new byte[BlockSizeInBytes];
            for (int i = 0; i < BlockSizeInBytes; ++i)
            {
                innerKey[i] = (byte)(key[i] ^ Ipad);
                outerKey[i] = (byte)(key[i] ^ Opad);
            }

            // for each block of desired output
            for (int iBlock = 0; iBlock < cBlocks; ++iBlock)
            {
                // seed HMAC with salt & block index
                IncrementBigEndianIndex(saltAndIndex, salt.Length);
                byte[] u = saltAndIndex;

                for (int i = 0; i < iterations; ++i)
                {
                    // simple implementation of HMAC-SHA-256
                    innerHash.Initialize();
                    innerHash.TransformBlock(innerKey, 0,
                        BlockSizeInBytes, innerKey, 0);
                    innerHash.TransformFinalBlock(u, 0, u.Length);

                    byte[] temp = innerHash.Hash;

                    outerHash.Initialize();
                    outerHash.TransformBlock(outerKey, 0,
                        BlockSizeInBytes, outerKey, 0);
                    outerHash.TransformFinalBlock(temp, 0, temp.Length);

                    u = outerHash.Hash; // U = result of HMAC

                    // xor result into output buffer
                    XorByteArray(u, 0, HashSizeInBytes,
                        output, outputOffset);
                }
                outputOffset += HashSizeInBytes;
            }
            byte[] result = new byte[howManyBytes];
            Array.Copy(output, 0, result, 0, howManyBytes);
            return result;
        }

        /// <summary>
        ///     Hashes the specified password.
        /// </summary>
        /// <param name="password">The password.</param>
        /// <param name="salt">The salt.</param>
        /// <returns>System.String.</returns>
        public static string Hash(string password, string salt)
        {
            byte[] bytes = GetBytes(password.GetBytesOfUTF8(), salt.GetBytesOfUTF8(), DefaultPBKDF2Interactions, DefaultPBKDF2Bytes);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        ///     Increments the index of the big endian.
        /// </summary>
        /// <param name="buf">The buf.</param>
        /// <param name="offset">The offset.</param>
        /// <exception cref="System.OverflowException"></exception>
        private static void IncrementBigEndianIndex(byte[] buf, int offset)
        {
            // treat the four bytes starting at buf[offset]
            // as a big endian integer, and increment it
            unchecked
            {
                if (0 == ++buf[offset + 3])
                    if (0 == ++buf[offset + 2])
                        if (0 == ++buf[offset + 1])
                            if (0 == ++buf[offset + 0])
                                throw new OverflowException();
            }
        }

        /// <summary>
        ///     Xors the byte array.
        /// </summary>
        /// <param name="src">The source.</param>
        /// <param name="srcOffset">The source offset.</param>
        /// <param name="cb">The cb.</param>
        /// <param name="dest">The dest.</param>
        /// <param name="destOffset">The dest offset.</param>
        private static void XorByteArray(byte[] src, int srcOffset, int cb, byte[] dest, int destOffset)
        {
            int end = checked(srcOffset + cb);
            while (srcOffset != end)
            {
                dest[destOffset] ^= src[srcOffset];
                ++srcOffset;
                ++destOffset;
            }
        }
    }
}
