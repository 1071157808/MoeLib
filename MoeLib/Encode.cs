// ***********************************************************************
// Assembly         : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  4:33 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-14  10:27 PM
// ***********************************************************************
// <copyright file="Encode.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;

namespace Moe.Lib
{
    /// <summary>
    ///     Utilities for working with Encode/Decode tasks.
    /// </summary>
    public static class EncodeUtility
    {
        /// <summary>
        ///     The base36 characters
        /// </summary>
        private const string Base36Characters = "0123456789abcdefghijklmnopqrstuvwxyz";

        /// <summary>
        ///     Decode the Base36 Encoded string into a number.
        /// </summary>
        /// <param name="input">The number to decode.</param>
        /// <returns>System.Int64.</returns>
        public static long Base36Decode(string input)
        {
            IEnumerable<char> reversed = input.ToLower().Reverse();
            long result = 0;
            int pos = 0;
            foreach (char c in reversed)
            {
                result += Base36Characters.IndexOf(c) * (long)Math.Pow(36, pos);
                pos++;
            }
            return result;
        }

        /// <summary>
        ///     Encode the given number into a Base36 string.
        /// </summary>
        /// <param name="input">The number to encode.</param>
        /// <returns>System.String.</returns>
        public static string Base36Encode(long input)
        {
            if (input < 0)
            {
                return string.Empty;
            }

            char[] clistarr = Base36Characters.ToCharArray();
            Stack<char> result = new Stack<char>();
            while (input != 0)
            {
                result.Push(clistarr[input % 36]);
                input /= 36;
            }
            return new String(result.ToArray());
        }

        /// <summary>
        ///     Decode the Base64 encoded string into a string using utf8.
        /// </summary>
        /// <param name="stringToDecode">The string to decode.</param>
        /// <returns>System.String.</returns>
        public static string Base64Decode(string stringToDecode)
        {
            try
            {
                return Convert.FromBase64String(stringToDecode).UTF8();
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        ///     Encode the given string into a Base64 string using utf8.
        /// </summary>
        /// <param name="stringToEncode">The string to encode.</param>
        /// <returns>System.String.</returns>
        public static string Base64Encode(string stringToEncode)
        {
            try
            {
                return Convert.ToBase64String(stringToEncode.GetBytesOfUTF8());
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        ///     Decode the HTML encoded string into a string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string HtmlDecode(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return value;
            }

            return WebUtility.HtmlDecode(value);
        }

        /// <summary>
        ///     Encode the given string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string HtmlEncode(string value)
        {
            if (value.IsNullOrEmpty())
            {
                return value;
            }

            return WebUtility.HtmlEncode(value);
        }

        /// <summary>
        ///     Encode the given javascript string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        public static string JavaScriptStringEncode(string value)
        {
            return JavaScriptStringEncode(value, false);
        }

        /// <summary>
        ///     Encode the given javascript string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="addDoubleQuotes">if set to <c>true</c> [add double quotes].</param>
        /// <returns>System.String.</returns>
        public static string JavaScriptStringEncode(string value, bool addDoubleQuotes)
        {
            string encoded = HttpEncoder.JavaScriptStringEncode(value);
            return (addDoubleQuotes) ? "\"" + encoded + "\"" : encoded;
        }

        /// <summary>
        ///     Decode the given string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string UrlDecode(string str)
        {
            if (str == null)
                return null;
            return HttpEncoder.UrlDecode(str, Encoding.UTF8);
        }

        /// <summary>
        ///     Encode the given string.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>System.String.</returns>
        public static string UrlEncode(string str)
        {
            if (str == null)
                return null;
            byte[] bytes = str.GetBytesOfUTF8();
            var encodedBytes = HttpEncoder.UrlEncode(bytes, 0, bytes.Length, false /* alwaysCreateNewReturnValue */);
            return encodedBytes.Ascii();
        }
    }

    /// <summary>
    ///     Class HttpEncoder.
    /// </summary>
    internal static class HttpEncoder
    {
        /// <summary>
        ///     Javas the script string encode.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>System.String.</returns>
        internal static string JavaScriptStringEncode(string value)
        {
            if (value.IsNotNullOrEmpty())
            {
                return value;
            }

            StringBuilder b = null;
            int startIndex = 0;
            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];

                // Append the unhandled characters (that do not require special treament)
                // to the string builder when special characters are detected.
                if (c == '\r' || c == '\t' || c == '\"' || c == '\'' || c == '<' || c == '>' ||
                    c == '\\' || c == '\n' || c == '\b' || c == '\f' || c < ' ')
                {
                    if (b == null)
                    {
                        b = new StringBuilder(value.Length + 5);
                    }

                    if (count > 0)
                    {
                        b.Append(value, startIndex, count);
                    }

                    startIndex = i + 1;
                    count = 0;
                }

                // ReSharper disable PossibleNullReferenceException
                switch (c)
                {
                    case '\r':
                        b.Append("\\r");
                        break;

                    case '\t':
                        b.Append("\\t");
                        break;

                    case '\"':
                        b.Append("\\\"");
                        break;

                    case '\\':
                        b.Append("\\\\");
                        break;

                    case '\n':
                        b.Append("\\intValue");
                        break;

                    case '\b':
                        b.Append("\\b");
                        break;

                    case '\f':
                        b.Append("\\f");
                        break;

                    case '\'':
                    case '>':
                    case '<':
                        AppendCharAsUnicodeJavaScript(b, c);
                        break;

                    default:
                        if (c < ' ')
                        {
                            AppendCharAsUnicodeJavaScript(b, c);
                        }
                        else
                        {
                            count++;
                        }
                        break;
                }
                // ReSharper restore PossibleNullReferenceException
            }

            if (b == null)
            {
                return value;
            }

            if (count > 0)
            {
                b.Append(value, startIndex, count);
            }

            return b.ToString();
        }

        /// <summary>
        ///     URLs the decode.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Byte[].</returns>
        internal static byte[] UrlDecode(byte[] bytes, int offset, int count)
        {
            if (!ValidateUrlEncodingParameters(bytes, offset, count))
            {
                return null;
            }

            int decodedBytesCount = 0;
            byte[] decodedBytes = new byte[count];

            for (int i = 0; i < count; i++)
            {
                int pos = offset + i;
                byte b = bytes[pos];

                if (b == '+')
                {
                    b = (byte)' ';
                }
                else if (b == '%' && i < count - 2)
                {
                    int h1 = HttpEncoderUtility.HexToInt((char)bytes[pos + 1]);
                    int h2 = HttpEncoderUtility.HexToInt((char)bytes[pos + 2]);

                    if (h1 >= 0 && h2 >= 0)
                    {
                        // valid 2 hex chars
                        b = (byte)((h1 << 4) | h2);
                        i += 2;
                    }
                }

                decodedBytes[decodedBytesCount++] = b;
            }

            if (decodedBytesCount < decodedBytes.Length)
            {
                byte[] newDecodedBytes = new byte[decodedBytesCount];
                Array.Copy(decodedBytes, newDecodedBytes, decodedBytesCount);
                decodedBytes = newDecodedBytes;
            }

            return decodedBytes;
        }

        /// <summary>
        ///     URLs the decode.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        internal static string UrlDecode(byte[] bytes, int offset, int count, Encoding encoding)
        {
            if (!ValidateUrlEncodingParameters(bytes, offset, count))
            {
                return null;
            }

            UrlDecoder helper = new UrlDecoder(count, encoding);

            // go through the bytes collapsing %XX and %uXXXX and appending
            // each byte as byte, with exception of %uXXXX constructs that
            // are appended as chars

            for (int i = 0; i < count; i++)
            {
                int pos = offset + i;
                byte b = bytes[pos];

                // The code assumes that + and % cannot be in multibyte sequence

                if (b == '+')
                {
                    b = (byte)' ';
                }
                else if (b == '%' && i < count - 2)
                {
                    if (bytes[pos + 1] == 'u' && i < count - 5)
                    {
                        int h1 = HttpEncoderUtility.HexToInt((char)bytes[pos + 2]);
                        int h2 = HttpEncoderUtility.HexToInt((char)bytes[pos + 3]);
                        int h3 = HttpEncoderUtility.HexToInt((char)bytes[pos + 4]);
                        int h4 = HttpEncoderUtility.HexToInt((char)bytes[pos + 5]);

                        if (h1 >= 0 && h2 >= 0 && h3 >= 0 && h4 >= 0)
                        {
                            // valid 4 hex chars
                            char ch = (char)((h1 << 12) | (h2 << 8) | (h3 << 4) | h4);
                            i += 5;

                            // don't add as byte
                            helper.AddChar(ch);
                            continue;
                        }
                    }
                    else
                    {
                        int h1 = HttpEncoderUtility.HexToInt((char)bytes[pos + 1]);
                        int h2 = HttpEncoderUtility.HexToInt((char)bytes[pos + 2]);

                        if (h1 >= 0 && h2 >= 0)
                        {
                            // valid 2 hex chars
                            b = (byte)((h1 << 4) | h2);
                            i += 2;
                        }
                    }
                }

                helper.AddByte(b);
            }

            return helper.GetString();
        }

        /// <summary>
        ///     URLs the decode.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns>System.String.</returns>
        internal static string UrlDecode(string value, Encoding encoding)
        {
            if (value == null)
            {
                return null;
            }

            int count = value.Length;
            UrlDecoder helper = new UrlDecoder(count, encoding);

            // go through the string's chars collapsing %XX and %uXXXX and
            // appending each char as char, with exception of %XX constructs
            // that are appended as bytes

            for (int pos = 0; pos < count; pos++)
            {
                char ch = value[pos];

                if (ch == '+')
                {
                    ch = ' ';
                }
                else if (ch == '%' && pos < count - 2)
                {
                    if (value[pos + 1] == 'u' && pos < count - 5)
                    {
                        int h1 = HttpEncoderUtility.HexToInt(value[pos + 2]);
                        int h2 = HttpEncoderUtility.HexToInt(value[pos + 3]);
                        int h3 = HttpEncoderUtility.HexToInt(value[pos + 4]);
                        int h4 = HttpEncoderUtility.HexToInt(value[pos + 5]);

                        if (h1 >= 0 && h2 >= 0 && h3 >= 0 && h4 >= 0)
                        {
                            // valid 4 hex chars
                            ch = (char)((h1 << 12) | (h2 << 8) | (h3 << 4) | h4);
                            pos += 5;

                            // only add as char
                            helper.AddChar(ch);
                            continue;
                        }
                    }
                    else
                    {
                        int h1 = HttpEncoderUtility.HexToInt(value[pos + 1]);
                        int h2 = HttpEncoderUtility.HexToInt(value[pos + 2]);

                        if (h1 >= 0 && h2 >= 0)
                        {
                            // valid 2 hex chars
                            byte b = (byte)((h1 << 4) | h2);
                            pos += 2;

                            // don't add as char
                            helper.AddByte(b);
                            continue;
                        }
                    }
                }

                if ((ch & 0xFF80) == 0)
                    helper.AddByte((byte)ch); // 7 bit have to go as bytes because of Unicode
                else
                    helper.AddChar(ch);
            }

            return helper.GetString();
        }

        /// <summary>
        ///     URLs the encode.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        /// <param name="alwaysCreateNewReturnValue">if set to <c>true</c> [always create new return value].</param>
        /// <returns>System.Byte[].</returns>
        internal static byte[] UrlEncode(byte[] bytes, int offset, int count, bool alwaysCreateNewReturnValue)
        {
            byte[] encoded = UrlEncode(bytes, offset, count);

            return (alwaysCreateNewReturnValue && (encoded != null) && (encoded == bytes))
                ? (byte[])encoded.Clone()
                : encoded;
        }

        /// <summary>
        ///     Appends the character as unicode java script.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="charValue">The character value.</param>
        private static void AppendCharAsUnicodeJavaScript(StringBuilder builder, char charValue)
        {
            builder.Append("\\u");
            builder.Append(((int)charValue).ToString("x4", CultureInfo.InvariantCulture));
        }

        /// <summary>
        ///     URLs the encode.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        /// <returns>System.Byte[].</returns>
        private static byte[] UrlEncode(byte[] bytes, int offset, int count)
        {
            if (!ValidateUrlEncodingParameters(bytes, offset, count))
            {
                return null;
            }

            int cSpaces = 0;
            int cUnsafe = 0;

            // count them first
            for (int i = 0; i < count; i++)
            {
                char ch = (char)bytes[offset + i];

                if (ch == ' ')
                    cSpaces++;
                else if (!HttpEncoderUtility.IsUrlSafeChar(ch))
                    cUnsafe++;
            }

            // nothing to expand?
            if (cSpaces == 0 && cUnsafe == 0)
                return bytes;

            // expand not 'safe' characters into %XX, spaces to +s
            byte[] expandedBytes = new byte[count + cUnsafe * 2];
            int pos = 0;

            for (int i = 0; i < count; i++)
            {
                byte b = bytes[offset + i];
                char ch = (char)b;

                if (HttpEncoderUtility.IsUrlSafeChar(ch))
                {
                    expandedBytes[pos++] = b;
                }
                else if (ch == ' ')
                {
                    expandedBytes[pos++] = (byte)'+';
                }
                else
                {
                    expandedBytes[pos++] = (byte)'%';
                    expandedBytes[pos++] = (byte)HttpEncoderUtility.IntToHex((b >> 4) & 0xf);
                    expandedBytes[pos++] = (byte)HttpEncoderUtility.IntToHex(b & 0x0f);
                }
            }

            return expandedBytes;
        }

        /// <summary>
        ///     Validates the URL encoding parameters.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="count">The count.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="System.ArgumentNullException">bytes</exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        ///     offset
        ///     or
        ///     count
        /// </exception>
        private static bool ValidateUrlEncodingParameters(byte[] bytes, int offset, int count)
        {
            if (bytes == null && count == 0)
                return false;
            if (bytes == null)
            {
                throw new ArgumentNullException("bytes");
            }
            if (offset < 0 || offset > bytes.Length)
            {
                throw new ArgumentOutOfRangeException("offset");
            }
            if (count < 0 || offset + count > bytes.Length)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            return true;
        }
    }

    /// <summary>
    ///     Class HttpEncoderUtility.
    /// </summary>
    internal static class HttpEncoderUtility
    {
        /// <summary>
        ///     Hexadecimals to int.
        /// </summary>
        /// <param name="hexValue">The hexValue.</param>
        /// <returns>System.Int32.</returns>
        internal static int HexToInt(char hexValue)
        {
            return (hexValue >= '0' && hexValue <= '9') ? hexValue - '0' :
                (hexValue >= 'a' && hexValue <= 'f') ? hexValue - 'a' + 10 :
                    (hexValue >= 'A' && hexValue <= 'F') ? hexValue - 'A' + 10 :
                        -1;
        }

        /// <summary>
        ///     Ints to hexadecimal.
        /// </summary>
        /// <param name="intValue">The intValue.</param>
        /// <returns>System.Char.</returns>
        internal static char IntToHex(int intValue)
        {
            if (intValue <= 9)
                return (char)(intValue + '0');
            return (char)(intValue - 10 + 'a');
        }

        // Set of safe chars, from RFC 1738.4 minus '+'
        /// <summary>
        ///     Determines whether [is URL safe character] [the specified charValue].
        /// </summary>
        /// <param name="charValue">The charValue.</param>
        /// <returns><c>true</c> if [is URL safe character] [the specified charValue]; otherwise, <c>false</c>.</returns>
        internal static bool IsUrlSafeChar(char charValue)
        {
            if (charValue >= 'a' && charValue <= 'z' || charValue >= 'A' && charValue <= 'Z' || charValue >= '0' && charValue <= '9')
                return true;

            switch (charValue)
            {
                case '-':
                case '_':
                case '.':
                case '!':
                case '*':
                case '(':
                case ')':
                    return true;
            }

            return false;
        }

        //  Helper to encode spaces only
        /// <summary>
        ///     URLs the encode spaces.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns>String.</returns>
        internal static String UrlEncodeSpaces(string str)
        {
            if (str != null && str.IndexOf(' ') >= 0)
                str = str.Replace(" ", "%20");
            return str;
        }
    }

    // Internal class to facilitate URL decoding -- keeps char buffer and byte buffer, allows appending of either chars or bytes
    /// <summary>
    ///     Class UrlDecoder.
    /// </summary>
    internal class UrlDecoder
    {
        /// <summary>
        ///     The buffer size
        /// </summary>
        private readonly int bufferSize;

        /// <summary>
        ///     The character buffer
        /// </summary>
        private readonly char[] charBuffer;

        // Encoding to convert chars to bytes
        /// <summary>
        ///     The encoding
        /// </summary>
        private readonly Encoding encoding;

        /// <summary>
        ///     The byte buffer
        /// </summary>
        private byte[] byteBuffer;

        // Accumulate bytes for decoding into characters in a special array
        /// <summary>
        ///     The number bytes
        /// </summary>
        private int numBytes;

        // Accumulate characters in a special array
        /// <summary>
        ///     The number chars
        /// </summary>
        private int numChars;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UrlDecoder" /> class.
        /// </summary>
        /// <param name="bufferSize">Size of the buffer.</param>
        /// <param name="encoding">The encoding.</param>
        internal UrlDecoder(int bufferSize, Encoding encoding)
        {
            this.bufferSize = bufferSize;
            this.encoding = encoding;

            charBuffer = new char[bufferSize];
            // byte buffer created on demand
        }

        /// <summary>
        ///     Adds the byte.
        /// </summary>
        /// <param name="byteValue">The byte value.</param>
        internal void AddByte(byte byteValue)
        {
            // if there are no pending bytes treat 7 bit bytes as characters
            // this optimization is temp disable as it doesn't work for some encodings
            /*
                            if (_numBytes == 0 && ((b & 0x80) == 0)) {
                                AddChar((char)b);
                            }
                            else
            */
            {
                if (byteBuffer == null)
                    byteBuffer = new byte[bufferSize];

                byteBuffer[numBytes++] = byteValue;
            }
        }

        /// <summary>
        ///     Adds the character.
        /// </summary>
        /// <param name="charValue">The charValue.</param>
        internal void AddChar(char charValue)
        {
            if (numBytes > 0)
                FlushBytes();

            charBuffer[numChars++] = charValue;
        }

        /// <summary>
        ///     Gets the string.
        /// </summary>
        /// <returns>String.</returns>
        internal String GetString()
        {
            if (numBytes > 0)
                FlushBytes();

            if (numChars > 0)
                return new String(charBuffer, 0, numChars);
            return String.Empty;
        }

        /// <summary>
        ///     Flushes the bytes.
        /// </summary>
        private void FlushBytes()
        {
            if (numBytes > 0)
            {
                numChars += encoding.GetChars(byteBuffer, 0, numBytes, charBuffer, numChars);
                numBytes = 0;
            }
        }
    }
}
