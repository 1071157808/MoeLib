// ***********************************************************************
// Project          : MoeLib
// Author           : Siqi Lu
// Created          : 2015-05-30  11:32 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-05-30  11:43 PM
// ***********************************************************************
// <copyright file="EnsuresExtensions.Collection.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Moe.Lib
{
    /// <summary>
    ///     Extensions of Ensures utility for the <see cref="IEnumerable{T}" />.
    /// </summary>
    public static partial class EnsuresExtensions
    {
        /// <summary>
        ///     Ensures all items in the given collection satisfy the given predicate.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection" />.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="predicate">Predicate to test/ensure.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> All<TCollection, TElement>(this Ensures<TCollection> ensures, Func<TElement, bool> predicate) where TCollection : IEnumerable<TElement>
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v != null && v.All(predicate));
        }

        /// <summary>
        ///     Ensures given collection contains a value that satisfied the predicate.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection" />.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="predicate">Predicate to test/ensure.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> Any<TCollection, TElement>(this Ensures<TCollection> ensures, Func<TElement, bool> predicate) where TCollection : IEnumerable<TElement>
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v != null && v.Any(predicate));
        }

        /// <summary>
        ///     Checks whether the given value contains the specified <paramref name="element" />.
        ///     When the value is a null reference it is considered empty and therefore won't contain <paramref name="element" />.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection" />.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> Contains<TCollection, TElement>(this Ensures<TCollection> ensures, TElement element) where TCollection : IEnumerable<TElement>
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v != null && v.Contains(element));
        }

        /// <summary>
        ///     Checks whether the given value does not contain the specified <paramref name="element" />.
        ///     When the value is a null reference it is considered empty and therefore won't contain <paramref name="element" />.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <typeparam name="TElement">The type that can be considered an element of the <typeparamref name="TCollection" />.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="element">The element that should contain the given value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> DoesNotContain<TCollection, TElement>(this Ensures<TCollection> ensures, TElement element) where TCollection : IEnumerable<TElement>
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v == null || !v.Contains(element));
        }

        /// <summary>
        ///     Checks whether the number of elements in the given value, is different from the specified
        ///     <paramref name="length" /> argument. When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="length">The number of elements the collection should not contain.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> DoesNotHaveLength<TCollection>(this Ensures<TCollection> ensures, int length) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.Not(v => v.GetLength() == length);
        }

        /// <summary>
        ///     Checks whether the given value has the number of elements as specified by
        ///     <paramref name="length" />. When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="length">The number of elements the collection should contain.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> HasLength<TCollection>(this Ensures<TCollection> ensures, int length) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v.GetLength() == length);
        }

        /// <summary>
        ///     Checks whether the given value contains no elements. When the value is a null reference it is considered empty.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> IsEmpty<TCollection>(this Ensures<TCollection> ensures) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v.IsNullOrEmpty());
        }

        /// <summary>
        ///     Checks whether the number of elements in the given value, is more than or equal to the specified
        ///     <paramref name="length" /> argument. When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="length">The collection must contain the same amount or more elements than this value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> IsLongerOrEqual<TCollection>(this Ensures<TCollection> ensures, int length) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v.GetLength() >= length);
        }

        /// <summary>
        ///     Checks whether the number of elements in the given value, is more than the specified
        ///     <paramref name="length" /> argument. When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="length">The collection must contain the same amount or less elements than this value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> IsLongerThan<TCollection>(this Ensures<TCollection> ensures, int length) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v.GetLength() > length);
        }

        /// <summary>
        ///     Checks whether the given value does contain elements.
        ///     When the value is a null reference it is considered empty.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> IsNotEmpty<TCollection>(this Ensures<TCollection> ensures) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.Not(v => v.IsNullOrEmpty());
        }

        /// <summary>
        ///     Checks whether the number of elements in the given value, is not more than and not equal to the
        ///     specified <paramref name="length" /> argument. When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="length">The collection must contain less elements than this value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> IsNotLongerOrEqual<TCollection>(this Ensures<TCollection> ensures, int length) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v.GetLength() < length);
        }

        /// <summary>
        ///     Checks whether the number of elements in the given value, is not more than the specified
        ///     <paramref name="length" /> argument. When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="length">The collection must contain the same amount or less elements than this value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> IsNotLongerThan<TCollection>(this Ensures<TCollection> ensures, int length) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v.GetLength() <= length);
        }

        /// <summary>
        ///     Checks whether the number of elements in the given value, is not less than and not equals to the
        ///     specified <paramref name="length" /> argument. When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="length">The collection must contain more elements than this value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> IsNotShorterOrEqual<TCollection>(this Ensures<TCollection> ensures, int length) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v.GetLength() > length);
        }

        /// <summary>
        ///     Checks whether the number of elements in the given value, is not less than the specified
        ///     <paramref name="length" /> argument. When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="length">The collection must contain the same amount or more elements than this value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> IsNotShorterThan<TCollection>(this Ensures<TCollection> ensures, int length) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v.GetLength() >= length);
        }

        /// <summary>
        ///     Checks whether the number of elements in the given value, is less than or equal to the specified
        ///     <paramref name="length" /> argument. When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="length">The collection must contain the same amount or less elements than this value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> IsShorterOrEqual<TCollection>(this Ensures<TCollection> ensures, int length) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v.GetLength() <= length);
        }

        /// <summary>
        ///     Checks whether the number of elements in the given value, is less than the specified
        ///     <paramref name="length" /> argument. When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <typeparam name="TCollection">The type of the collection to test/ensure.</typeparam>
        /// <param name="ensures">The <see cref="Ensures{T}" /> that holds the value that has to be test/ensure.</param>
        /// <param name="length">The collection must contain less elements than this value.</param>
        /// <returns>The specified <paramref name="ensures" /> instance.</returns>
        public static Ensures<TCollection> IsShorterThan<TCollection>(this Ensures<TCollection> ensures, int length) where TCollection : IEnumerable
        {
            if (ensures == null)
            {
                throw new ArgumentNullException(nameof(ensures));
            }

            return ensures.That(v => v.GetLength() < length);
        }
    }
}