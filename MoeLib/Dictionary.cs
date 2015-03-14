// ***********************************************************************
// Assembly         : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  1:51 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-14  10:59 PM
// ***********************************************************************
// <copyright file="DictionaryExtensions.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Collections.Generic;

namespace Moe.Lib
{
    /// <summary>
    ///     Extension methods for <see cref="System.Collections.Generic.IDictionary{TKey, TValue}" />
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        ///     Gets the value associated with the specified key or the <paramref name="defaultValue" /> if it does not exist.
        /// </summary>
        /// <param name="dictionary">The dictionary object.</param>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="defaultValue">The default value to return if an item with the specified <paramref name="key" /> does not exist.</param>
        /// <returns>The value associated with the specified key or the <paramref name="defaultValue" /> if it does not exist.</returns>
        public static TValue GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            TValue value;
            return dictionary.TryGetValue(key, out value) ? value : defaultValue;
        }
    }
}
