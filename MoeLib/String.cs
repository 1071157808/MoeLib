// ***********************************************************************
// Assembly         : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  10:17 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-16  12:01 AM
// ***********************************************************************
// <copyright file="String.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Moe.Lib
{
    /// <summary>
    ///     Extensions for <see cref="System.String" />.
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        ///     Converts a string to a strongly typed value of the specified data type.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <typeparam name="TValue">The data type to convert to.</typeparam>
        public static TValue As<TValue>(this string value)
        {
            return StringUtility.As<TValue>(value);
        }

        /// <summary>
        ///     Converts a string to the specified data type and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null.</param>
        /// <typeparam name="TValue">The data type to convert to.</typeparam>
        public static TValue As<TValue>(this string value, TValue defaultValue)
        {
            return StringUtility.As(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a Boolean (true/false) value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static bool AsBool(this string value)
        {
            return StringUtility.AsBool(value);
        }

        /// <summary>
        ///     Converts a string to a Boolean (true/false) value and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static bool AsBool(this string value, bool defaultValue)
        {
            return StringUtility.AsBool(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.DateTime" /> value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static DateTime AsDateTime(this string value)
        {
            return StringUtility.AsDateTime(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.DateTime" /> value and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value. The default is the minimum time value on the system.</param>
        public static DateTime AsDateTime(this string value, DateTime defaultValue)
        {
            return StringUtility.AsDateTime(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Decimal" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static decimal AsDecimal(this string value)
        {
            return StringUtility.AsDecimal(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Decimal" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or invalid.</param>
        public static decimal AsDecimal(this string value, decimal defaultValue)
        {
            return StringUtility.AsDecimal(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Double" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static double AsDouble(this string value)
        {
            return StringUtility.AsDouble(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Double" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or invalid.</param>
        public static double AsDouble(this string value, double defaultValue)
        {
            return StringUtility.AsDouble(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.float" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static float AsFloat(this string value)
        {
            return StringUtility.AsFloat(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.float" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null.</param>
        public static float AsFloat(this string value, float defaultValue)
        {
            return StringUtility.AsFloat(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.int" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static int AsInt(this string value)
        {
            return StringUtility.AsInt(value);
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static int AsInt(this string value, int defaultValue)
        {
            return StringUtility.AsInt(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int16" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int16 AsInt16(this string value)
        {
            return StringUtility.AsInt16(value);
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static Int16 AsInt16(this string value, Int16 defaultValue)
        {
            return StringUtility.AsInt16(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int32" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int32 AsInt32(this string value)
        {
            return StringUtility.AsInt32(value);
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static Int32 AsInt32(this string value, Int32 defaultValue)
        {
            return StringUtility.AsInt32(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int64" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int64 AsInt64(this string value)
        {
            return StringUtility.AsInt64(value);
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static Int64 AsInt64(this string value, Int64 defaultValue)
        {
            return StringUtility.AsInt64(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.long" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static long AsLong(this string value)
        {
            return StringUtility.AsLong(value);
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static long AsLong(this string value, long defaultValue)
        {
            return StringUtility.AsLong(value, defaultValue);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Single" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Single AsSingle(this string value)
        {
            return StringUtility.AsSingle(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Single" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null.</param>
        public static Single AsSingle(this string value, Single defaultValue)
        {
            return StringUtility.AsSingle(value, defaultValue);
        }

        /// <summary>
        ///     Concats the specified target.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="target">The target.</param>
        /// <returns>System.String.</returns>
        public static string Concat(this string source, string target)
        {
            return string.Concat(source, target);
        }

        /// <summary>
        ///     Checks if the <paramref name="source" /> contains the <paramref name="input" /> based on the provided <paramref name="comparison" /> rules.
        /// </summary>
        public static bool Contains(this string source, string input, StringComparison comparison)
        {
            return StringUtility.Contains(source, input, comparison);
        }

        /// <summary>
        ///     Checks if the <paramref name="source" /> contains the <paramref name="input" />.
        /// </summary>
        public static bool Contains(this string source, string input)
        {
            return StringUtility.Contains(source, input);
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.Format(string, object[])" />
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatWith(this string format, params object[] args)
        {
            return StringUtility.FormatWith(format, args);
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.Format(string, object[])" />
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="provider">String format provider</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatWith(this string format, IFormatProvider provider, params object[] args)
        {
            return StringUtility.FormatWith(format, provider, args);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the specified data type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The value to test.</param>
        /// <typeparam name="TValue">The data type to convert to.</typeparam>
        public static bool Is<TValue>(this string value)
        {
            return StringUtility.Is<TValue>(value);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the Boolean (true/false) type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsBool(this string value)
        {
            return StringUtility.IsBool(value);
        }

        /// <summary>
        ///     Validates whether the provided
        ///     <param name="value">string</param>
        ///     is a valid cellphone number(13712341234).
        /// </summary>
        public static bool IsCellphone(this string value)
        {
            return StringUtility.IsCellphone(value);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the <see cref="T:System.DateTime" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsDateTime(this string value)
        {
            return StringUtility.IsDateTime(value);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the <see cref="T:System.Decimal" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsDecimal(this string value)
        {
            return StringUtility.IsDecimal(value);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the Boolean (true/false) type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsDouble(this string value)
        {
            return StringUtility.IsDouble(value);
        }

        /// <summary>
        ///     Validates whether the provided
        ///     <param name="value">string</param>
        ///     is a valid Email Address.
        /// </summary>
        public static bool IsEmail(this string value)
        {
            return StringUtility.IsEmail(value);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the <see cref="T:System.Single" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsFloat(this string value)
        {
            return StringUtility.IsFloat(value);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the <see cref="T:System.int" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsInt(this string value)
        {
            return StringUtility.IsInt(value);
        }

        /// <summary>
        ///     Checks whether a string can be converted to to the <see cref="T:System.Int16" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsInt16(this string value)
        {
            return StringUtility.IsInt16(value);
        }

        /// <summary>
        ///     Checks whether a string can be converted to to the <see cref="T:System.Int32" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsInt32(this string value)
        {
            return StringUtility.IsInt32(value);
        }

        /// <summary>
        ///     Checks whether a string can be converted to to the <see cref="T:System.Int64" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsInt64(this string value)
        {
            return StringUtility.IsInt64(value);
        }

        /// <summary>
        ///     Validates whether the provided
        ///     <param name="value">string</param>
        ///     is a valid IP Address.
        /// </summary>
        public static bool IsIpAddress(this string value)
        {
            return StringUtility.IsIpAddress(value);
        }

        /// <summary>
        ///     Checks whether a string can be converted to a long.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsLong(this string value)
        {
            return StringUtility.IsLong(value);
        }

        /// <summary>
        ///     A nicer way of calling the inverse of <see cref="System.String.IsNullOrEmpty(string)" />
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is not null or an empty string (""); otherwise, false.</returns>
        public static bool IsNotNullOrEmpty(this string value)
        {
            return StringUtility.IsNotNullOrEmpty(value);
        }

        /// <summary>
        ///     A nicer way of calling the inverse of <see cref="System.String.IsNullOrWhiteSpace(string)" />
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is not null or an empty string (""); otherwise, false.</returns>
        public static bool IsNotNullOrWhiteSpace(this string value)
        {
            return StringUtility.IsNotNullOrWhiteSpace(value);
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.IsNullOrEmpty(string)" />
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return StringUtility.IsNullOrEmpty(value);
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.IsNullOrWhiteSpace(string)" />
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return StringUtility.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        ///     Validates whether the provided
        ///     <param name="value">string</param>
        ///     is a valid (absolute) URL.
        /// </summary>
        public static bool IsUrl(this string value) // absolute
        {
            return StringUtility.IsUrl(value);
        }

        /// <summary>
        ///     Limits the length of the <paramref name="source" /> to the specified <paramref name="maxLength" />.
        /// </summary>
        public static string Limit(this string source, int maxLength, string suffix = "")
        {
            return StringUtility.Limit(source, maxLength, suffix);
        }

        /// <summary>
        ///     Matches the specified regex.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="regex">The regex.</param>
        /// <returns><c>true</c> if match, <c>false</c> otherwise.</returns>
        public static bool Match(this string value, Regex regex)
        {
            return StringUtility.Match(value, regex);
        }

        /// <summary>
        ///     Gets the string md5 hash.
        /// </summary>
        /// <param name="stringToHash">The string to hash.</param>
        /// <returns>System.String.</returns>
        public static string MD5Hash(this string stringToHash)
        {
            return StringUtility.MD5Hash(stringToHash);
        }

        /// <summary>
        ///     Removes the specified target string from value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="target">The target.</param>
        /// <returns>System.String.</returns>
        public static string Remove(this string value, string target)
        {
            return StringUtility.Remove(value, target);
        }

        /// <summary>
        ///     Separates a PascalCase string
        /// </summary>
        /// <example>
        ///     "ThisIsPascalCase".SeparatePascalCase(); // returns "This Is Pascal Case"
        /// </example>
        /// <param name="value">The value to split</param>
        /// <returns>The original string separated on each uppercase character.</returns>
        public static string SeparatePascalCase(this string value)
        {
            return StringUtility.SeparatePascalCase(value);
        }

        /// <summary>
        ///     Returns a string array containing the trimmed substrings in this <paramref name="value" />
        ///     that are delimited by the provided <paramref name="separators" />.
        /// </summary>
        public static IEnumerable<string> SplitAndTrim(this string value, params char[] separators)
        {
            return StringUtility.SplitAndTrim(value, separators);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.bool" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static bool ToBool(this string value)
        {
            return StringUtility.ToBool(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.DateTime" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static DateTime ToDateTime(this string value)
        {
            return StringUtility.ToDateTime(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.decimal" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static decimal ToDecimal(this string value)
        {
            return StringUtility.ToDecimal(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.double" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static double ToDouble(this string value)
        {
            return StringUtility.ToDouble(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.float" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static float ToFloat(this string value)
        {
            return StringUtility.ToFloat(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.int" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static int ToInt(this string value)
        {
            return StringUtility.ToInt(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int16" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int16 ToInt16(this string value)
        {
            return StringUtility.ToInt16(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int32" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int32 ToInt32(this string value)
        {
            return StringUtility.ToInt32(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int64" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int64 ToInt64(this string value)
        {
            return StringUtility.ToInt64(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.long" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static long ToLong(this string value)
        {
            return StringUtility.ToLong(value);
        }

        /// <summary>
        ///     Allows for using strings in null coalescing operations
        /// </summary>
        /// <param name="value">The string value to check</param>
        /// <returns>Null if <paramref name="value" /> is empty or the original value of <paramref name="value" />.</returns>
        public static string ToNullIfEmpty(this string value)
        {
            return StringUtility.ToNullIfEmpty(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Single" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Single ToSingle(this string value)
        {
            return StringUtility.ToSingle(value);
        }
    }

    /// <summary>
    ///     Utilities for working with <see cref="System.String" /> type.
    /// </summary>
    public static class StringUtility
    {
        /// <summary>
        ///     Converts a string to a strongly typed value of the specified data type.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <typeparam name="TValue">The data type to convert to.</typeparam>
        public static TValue As<TValue>(string value)
        {
            return As(value, default(TValue));
        }

        /// <summary>
        ///     Converts a string to the specified data type and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null.</param>
        /// <typeparam name="TValue">The data type to convert to.</typeparam>
        public static TValue As<TValue>(string value, TValue defaultValue)
        {
            try
            {
                TypeConverter converter1 = TypeDescriptor.GetConverter(typeof(TValue));
                if (converter1.CanConvertFrom(typeof(string)))
                    return (TValue)converter1.ConvertFrom(value);
                TypeConverter converter2 = TypeDescriptor.GetConverter(typeof(string));
                if (converter2.CanConvertTo(typeof(TValue)))
                    return (TValue)converter2.ConvertTo(value, typeof(TValue));
            }
            catch
            {
            }
            return defaultValue;
        }

        /// <summary>
        ///     Converts a string to a Boolean (true/false) value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static bool AsBool(string value)
        {
            return AsBool(value, false);
        }

        /// <summary>
        ///     Converts a string to a Boolean (true/false) value and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static bool AsBool(string value, bool defaultValue)
        {
            bool result;
            return !bool.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.DateTime" /> value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static DateTime AsDateTime(string value)
        {
            return AsDateTime(value, DateTime.UtcNow);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.DateTime" /> value and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value. The default is the minimum time value on the system.</param>
        public static DateTime AsDateTime(string value, DateTime defaultValue)
        {
            DateTime result;
            return !DateTime.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Decimal" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static decimal AsDecimal(string value)
        {
            return AsDecimal(value, 0m);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Decimal" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or invalid.</param>
        public static decimal AsDecimal(string value, decimal defaultValue)
        {
            decimal result;
            return !decimal.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Double" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static double AsDouble(string value)
        {
            return AsDouble(value, 0d);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Double" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or invalid.</param>
        public static double AsDouble(string value, double defaultValue)
        {
            double result;
            return !double.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.float" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static float AsFloat(string value)
        {
            return AsFloat(value, 0.0f);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.float" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null.</param>
        public static float AsFloat(string value, float defaultValue)
        {
            float result;
            return !float.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.int" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static int AsInt(string value)
        {
            return AsInt(value, 0);
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static int AsInt(string value, int defaultValue)
        {
            int result;
            return !int.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int16" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int16 AsInt16(string value)
        {
            return AsInt16(value, 0);
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static Int16 AsInt16(string value, Int16 defaultValue)
        {
            Int16 result;
            return !Int16.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int32" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int32 AsInt32(string value)
        {
            return AsInt32(value, 0);
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static Int32 AsInt32(string value, Int32 defaultValue)
        {
            Int32 result;
            return !Int32.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int64" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int64 AsInt64(string value)
        {
            return AsInt64(value, 0);
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static Int64 AsInt64(string value, Int64 defaultValue)
        {
            Int64 result;
            return !Int64.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.long" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static long AsLong(string value)
        {
            return AsLong(value, 0L);
        }

        /// <summary>
        ///     Converts a string to to a <see cref="T:System.int" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null or is an invalid value.</param>
        public static long AsLong(string value, long defaultValue)
        {
            long result;
            return !long.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Single" /> number.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Single AsSingle(string value)
        {
            return AsSingle(value, 0.0f);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Single" /> number and specifies a default value.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        /// <param name="defaultValue">The value to return if <paramref name="value" /> is null.</param>
        public static Single AsSingle(string value, Single defaultValue)
        {
            Single result;
            return !float.TryParse(value, out result) ? defaultValue : result;
        }

        /// <summary>
        ///     Checks if the <paramref name="source" /> contains the <paramref name="input" /> based on the provided <paramref name="comparison" /> rules.
        /// </summary>
        public static bool Contains(string source, string input, StringComparison comparison)
        {
            return source.IndexOf(input, comparison) >= 0;
        }

        /// <summary>
        ///     Checks if the <paramref name="source" /> contains the <paramref name="input" />.
        /// </summary>
        public static bool Contains(string source, string input)
        {
            return source.IndexOf(input, StringComparison.Ordinal) >= 0;
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.Format(string, object[])" />
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatWith(string format, params object[] args)
        {
            return string.Format(format, args);
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.Format(string, object[])" />
        /// </summary>
        /// <param name="format">A composite format string.</param>
        /// <param name="provider">String format provider</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// <returns>A copy of format in which the format items have been replaced by the string representation of the corresponding objects in args.</returns>
        public static string FormatWith(string format, IFormatProvider provider, params object[] args)
        {
            return string.Format(provider, format, args);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the specified data type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The value to test.</param>
        /// <typeparam name="TValue">The data type to convert to.</typeparam>
        public static bool Is<TValue>(string value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(TValue));
            try
            {
                if (value != null)
                {
                    if (!converter.CanConvertFrom(null, value.GetType()))
                        goto label_5;
                }
                converter.ConvertFrom(null, CultureInfo.CurrentCulture, value);
                return true;
            }
            catch
            {
            }
            label_5:
            return false;
        }

        /// <summary>
        ///     Checks whether a string can be converted to the Boolean (true/false) type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsBool(string value)
        {
            bool result;
            return bool.TryParse(value, out result);
        }

        /// <summary>
        ///     Validates whether the provided
        ///     <param name="value">string</param>
        ///     is a valid cellphone number(13712341234).
        /// </summary>
        public static bool IsCellphone(string value)
        {
            return Match(value, RegexUtility.CellphoneRegex);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the <see cref="T:System.DateTime" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsDateTime(string value)
        {
            DateTime result;
            return DateTime.TryParse(value, out result);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the <see cref="T:System.Decimal" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsDecimal(string value)
        {
            decimal result;
            return decimal.TryParse(value, out result);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the Boolean (true/false) type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsDouble(string value)
        {
            double result;
            return double.TryParse(value, out result);
        }

        /// <summary>
        ///     Validates whether the provided
        ///     <param name="value">string</param>
        ///     is a valid Email Address.
        /// </summary>
        public static bool IsEmail(string value)
        {
            return Match(value, RegexUtility.EmailRegex);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the <see cref="T:System.Single" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsFloat(string value)
        {
            float result;
            return float.TryParse(value, out result);
        }

        /// <summary>
        ///     Checks whether a string can be converted to the <see cref="T:System.int" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsInt(string value)
        {
            int result;
            return int.TryParse(value, out result);
        }

        /// <summary>
        ///     Checks whether a string can be converted to to the <see cref="T:System.Int16" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsInt16(string value)
        {
            Int16 result;
            return Int16.TryParse(value, out result);
        }

        /// <summary>
        ///     Checks whether a string can be converted to to the <see cref="T:System.Int32" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsInt32(string value)
        {
            Int32 result;
            return Int32.TryParse(value, out result);
        }

        /// <summary>
        ///     Checks whether a string can be converted to to the <see cref="T:System.Int64" /> type.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsInt64(string value)
        {
            Int64 result;
            return Int64.TryParse(value, out result);
        }

        /// <summary>
        ///     Validates whether the provided
        ///     <param name="value">string</param>
        ///     is a valid IP Address.
        /// </summary>
        public static bool IsIpAddress(string value)
        {
            return Match(value, RegexUtility.IPAddressRegex);
        }

        /// <summary>
        ///     Checks whether a string can be converted to a long.
        /// </summary>
        /// <returns>
        ///     true if <paramref name="value" /> can be converted to the specified type; otherwise, false.
        /// </returns>
        /// <param name="value">The string value to test.</param>
        public static bool IsLong(string value)
        {
            long result;
            return long.TryParse(value, out result);
        }

        /// <summary>
        ///     A nicer way of calling the inverse of <see cref="System.String.IsNullOrEmpty(string)" />
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is not null or an empty string (""); otherwise, false.</returns>
        public static bool IsNotNullOrEmpty(string value)
        {
            return !string.IsNullOrEmpty(value);
        }

        /// <summary>
        ///     A nicer way of calling the inverse of <see cref="System.String.IsNullOrWhiteSpace(string)" />
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is not null or an empty string (""); otherwise, false.</returns>
        public static bool IsNotNullOrWhiteSpace(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.IsNullOrEmpty(string)" />
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrEmpty(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        /// <summary>
        ///     A nicer way of calling <see cref="System.String.IsNullOrWhiteSpace(string)" />
        /// </summary>
        /// <param name="value">The string to test.</param>
        /// <returns>true if the value parameter is null or an empty string (""); otherwise, false.</returns>
        public static bool IsNullOrWhiteSpace(string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        ///     Validates whether the provided
        ///     <param name="value">string</param>
        ///     is a valid (absolute) URL.
        /// </summary>
        public static bool IsUrl(string value) // absolute
        {
            return Match(value, RegexUtility.UrlRegex);
        }

        /// <summary>
        ///     Limits the length of the <paramref name="source" /> to the specified <paramref name="maxLength" />.
        /// </summary>
        public static string Limit(string source, int maxLength, string suffix = "")
        {
            if (suffix.IsNotNullOrEmpty())
            {
                maxLength = maxLength - suffix.Length;
            }

            if (source.Length <= maxLength)
            {
                return source;
            }

            return string.Concat(source.Substring(0, maxLength).Trim(), suffix ?? string.Empty);
        }

        /// <summary>
        ///     Matches the specified regex.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="regex">The regex.</param>
        /// <returns><c>true</c> if match, <c>false</c> otherwise.</returns>
        public static bool Match(string value, Regex regex)
        {
            return value.IsNotNullOrEmpty() || regex.IsMatch(value);
        }

        /// <summary>
        ///     Gets the string md5 hash.
        /// </summary>
        /// <param name="stringToHash">The string to hash.</param>
        /// <returns>System.String.</returns>
        public static string MD5Hash(string stringToHash)
        {
            return Lib.MD5Hash.ComputeMD5Hash(stringToHash);
        }

        /// <summary>
        ///     Removes the specified target string from value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="target">The target.</param>
        /// <returns>System.String.</returns>
        public static string Remove(string value, string target)
        {
            if (value == null)
            {
                return null;
            }
            return value.Replace(target, "");
        }

        /// <summary>
        ///     Separates a PascalCase string
        /// </summary>
        /// <example>
        ///     "ThisIsPascalCase".SeparatePascalCase(); // returns "This Is Pascal Case"
        /// </example>
        /// <param name="value">The value to split</param>
        /// <returns>The original string separated on each uppercase character.</returns>
        public static string SeparatePascalCase(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            return Regex.Replace(value, "([A-Z])", " $1").Trim();
        }

        /// <summary>
        ///     Returns a string array containing the trimmed substrings in this <paramref name="value" />
        ///     that are delimited by the provided <paramref name="separators" />.
        /// </summary>
        public static IEnumerable<string> SplitAndTrim(string value, params char[] separators)
        {
            value = value ?? string.Empty;
            return value.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Trim());
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.bool" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static bool ToBool(string value)
        {
            return bool.Parse(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.DateTime" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static DateTime ToDateTime(string value)
        {
            return DateTime.Parse(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.decimal" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static decimal ToDecimal(string value)
        {
            return decimal.Parse(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.double" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static double ToDouble(string value)
        {
            return double.Parse(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.float" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static float ToFloat(string value)
        {
            return float.Parse(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.int" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static int ToInt(string value)
        {
            return int.Parse(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int16" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int16 ToInt16(string value)
        {
            return Int16.Parse(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int32" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int32 ToInt32(string value)
        {
            return Int32.Parse(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Int64" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Int64 ToInt64(string value)
        {
            return Int64.Parse(value);
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.long" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static long ToLong(string value)
        {
            return long.Parse(value);
        }

        /// <summary>
        ///     Allows for using strings in null coalescing operations
        /// </summary>
        /// <param name="value">The string value to check</param>
        /// <returns>Null if <paramref name="value" /> is empty or the original value of <paramref name="value" />.</returns>
        public static string ToNullIfEmpty(string value)
        {
            return value == string.Empty ? null : value;
        }

        /// <summary>
        ///     Converts a string to a <see cref="T:System.Single" /> or throw an exception if the string is in a bad format.
        /// </summary>
        /// <returns>
        ///     The converted value.
        /// </returns>
        /// <param name="value">The value to convert.</param>
        public static Single ToSingle(string value)
        {
            return Single.Parse(value);
        }
    }
}
