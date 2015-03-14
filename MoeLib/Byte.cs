// ***********************************************************************
// Assembly         : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  4:36 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-14  6:39 PM
// ***********************************************************************
// <copyright file="Byte.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Text;

namespace Moe.Lib
{
    /// <summary>
    ///     Extensions of <see cref="System.Byte" /> types.
    /// </summary>
    public static class ByteExtensions
    {
        /// <summary>
        ///     Gets ASCII string of specified byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Ascii(this byte value)
        {
            return ByteUtility.Ascii(value);
        }

        /// <summary>
        ///     Gets ASCII string of specified byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Ascii(this byte[] value)
        {
            return ByteUtility.Ascii(value);
        }

        /// <summary>
        ///     Gets the bytes of ASCII string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfAscii(this string value)
        {
            return ByteUtility.GetBytesOfAscii(value);
        }

        /// <summary>
        ///     Gets the bytes of unicode string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfUnicode(this string value)
        {
            return ByteUtility.GetBytesOfUnicode(value);
        }

        /// <summary>
        ///     Gets the bytes of utf8 string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfUTF8(this string value)
        {
            return ByteUtility.GetBytesOfUTF8(value);
        }

        /// <summary>
        ///     Hexadecimals the specified byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Hex(this byte value)
        {
            return ByteUtility.Hex(value);
        }

        /// <summary>
        ///     Hexadecimals the specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string Hex(this byte[] bytes)
        {
            return ByteUtility.Hex(bytes);
        }

        /// <summary>
        ///     Gets Unicode string of specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string Unicode(this byte[] bytes)
        {
            return ByteUtility.Unicode(bytes);
        }

        /// <summary>
        ///     Gets UTF8 string of specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string UTF8(this byte[] bytes)
        {
            return ByteUtility.UTF8(bytes);
        }
    }

    /// <summary>
    ///     Utilities for working with <see cref="System.Byte" /> type.
    /// </summary>
    public static class ByteUtility
    {
        /// <summary>
        ///     Gets ASCII string of specified byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Ascii(byte value)
        {
            return Encoding.ASCII.GetString(new[] { value });
        }

        /// <summary>
        ///     Gets ASCII string of specified byte array.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Ascii(byte[] value)
        {
            if (value == null)
                return null;
            value = value.FixBom();
            return Encoding.ASCII.GetString(value);
        }

        /// <summary>
        ///     Gets the bytes of ASCII string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfAscii(string value)
        {
            return Encoding.ASCII.GetBytes(value);
        }

        /// <summary>
        ///     Gets the bytes of unicode string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfUnicode(string value)
        {
            return Encoding.Unicode.GetBytes(value);
        }

        /// <summary>
        ///     Gets the bytes of utf8 string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] GetBytesOfUTF8(string value)
        {
            return Encoding.UTF8.GetBytes(value);
        }

        /// <summary>
        ///     Hexadecimals the specified byte.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string Hex(byte value)
        {
            return value.ToString("x2").ToUpperInvariant();
        }

        /// <summary>
        ///     Hexadecimals the specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string Hex(byte[] bytes)
        {
            if (bytes == null)
                return "";

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
                stringBuilder.Append(bytes[i].Hex());

            return stringBuilder.ToString();
        }

        /// <summary>
        ///     Gets Unicode string of specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string Unicode(byte[] bytes)
        {
            return bytes == null ? null : Encoding.Unicode.GetString(bytes);
        }

        /// <summary>
        ///     Gets UTF8 string of specified byte array.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>System.String.</returns>
        public static string UTF8(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        /// <summary>
        ///     Fixes the bom.
        /// </summary>
        /// <param name="bytesToFix">The bytes to fix.</param>
        /// <returns>System.Byte[].</returns>
        private static byte[] FixBom(this byte[] bytesToFix)
        {
            //see BOM - Byte Order Mark : http://en.wikipedia.org/wiki/Byte_order_mark
            //    http://www.verious.com/qa/-239-187-191-characters-appended-to-the-beginning-of-each-file/
            //    http://social.msdn.microsoft.com/Forums/en-US/8956758d-9814-4bd4-9812-e82903640b2f/recieving-239187191-character-symbols-when-loading-text-files-not-containing-them
            if (bytesToFix != null && bytesToFix.Length > 3 && (bytesToFix[0] == '\xEF' && bytesToFix[1] == '\xBB' && bytesToFix[2] == '\xBF'))
                return bytesToFix.RemoveBytes(2);

            return bytesToFix;
        }

        /// <summary>
        ///     Removes the bytes.
        /// </summary>
        /// <param name="originalBytes">The original bytes.</param>
        /// <param name="removeFrom">The remove from.</param>
        /// <returns>System.Byte[].</returns>
        private static byte[] RemoveBytes(this byte[] originalBytes, uint removeFrom)
        {
            if (originalBytes.Length > removeFrom)
            {
                var newSize = originalBytes.Length - removeFrom - 1;
                var bytes = new byte[newSize];
                Array.Copy(originalBytes, removeFrom + 1, bytes, 0, newSize);
                return bytes;
            }

            return new byte[0];
        }
    }
}
