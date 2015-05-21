// ***********************************************************************
// Project          : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  10:58 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-05-21  9:30 PM
// ***********************************************************************
// <copyright file="Stringification.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;

namespace Moe.Lib
{
    /// <summary>
    ///     A helper class with extension methods for converting an object to a string representation.
    /// </summary>
    public static class Stringification
    {
        private const int MaximumNumberOfRecursiveCalls = 10;

        /// <summary>
        ///     Transforms an object into a string representation that can be used to represent it's value in an
        ///     exception message. When the value is a null reference, the string "null" will be returned, when
        ///     the specified value is a string or a char, it will be surrounded with single quotes.
        /// </summary>
        /// <param name="value">The value to be transformed.</param>
        /// <returns>A string representation of the supplied <paramref name="value" />.</returns>
        public static string Stringify(this object value)
        {
            try
            {
                return StringifyInternal(value, MaximumNumberOfRecursiveCalls);
            }
            catch (InvalidOperationException)
            {
                // Stack overflow prevented. We can not build a string representation of the supplied object.
                // We return the default representation of the object.
                Debug.Assert(value != null, "value should not be null when InvalidOperation is thrown.");
                return value.ToString();
            }
        }

        /// <summary>
        ///     Transforms an object into a json string representation. When the value is a null reference, the string "null" will be returned.
        /// </summary>
        /// <param name="value">The value to be transformed.</param>
        /// <returns>A string representation of the supplied <paramref name="value" />.</returns>
        public static string ToJson(this object value)
        {
            if (value == null)
            {
                return null;
            }
            try
            {
                return JsonConvert.SerializeObject(value);
            }
            catch
            {
                return value.ToString();
            }
        }

        private static string StringifyCollection(IEnumerable collection, int maximumNumberOfRecursiveCalls)
        {
            return "{" + String.Join(",", (from object o in collection select StringifyInternal(o, maximumNumberOfRecursiveCalls - 1)).ToArray()) + "}";
        }

        private static string StringifyInternal(object value, int maximumNumberOfRecursiveCalls)
        {
            if (value == null)
            {
                return "null";
            }

            if (maximumNumberOfRecursiveCalls < 0)
            {
                // Prevent stack overflow exceptions.
                throw new InvalidOperationException();
            }

            if (value is string || value is char)
            {
                return "'" + value + "'";
            }

            IEnumerable collection = value as IEnumerable;

            return collection != null ? StringifyCollection(collection, maximumNumberOfRecursiveCalls) : value.ToString();
        }
    }
}