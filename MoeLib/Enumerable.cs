// ***********************************************************************
// Project          : MoeLib
// File             : Enumerable.cs
// Created          : 2015-03-14  11:05 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-08-11  2:39 PM
// ***********************************************************************
// <copyright file="Enumerable.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace Moe.Lib
{
    /// <summary>
    ///     Extension methods for <see cref="System.Collections.Generic.IEnumerable{T}" />
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        ///     Performs an action on each value of the sequence
        /// </summary>
        /// <typeparam name="T">Sequence element type.</typeparam>
        /// <param name="sequence">Sequence on which to perform action</param>
        /// <param name="action">Action to perform on every item</param>
        /// <exception cref="System.ArgumentNullException">Thrown when given null <paramref name="sequence" /> or <paramref name="action" /></exception>
        public static void ForEach<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            IList<T> values = sequence as IList<T> ?? sequence.ToList();
            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (T value in values)
            {
                action(value);
            }
        }

        /// <summary>
        ///     Performs an action on each value of the sequence
        /// </summary>
        /// <typeparam name="T">Sequence element type.</typeparam>
        /// <typeparam name="TResult">Result element type.</typeparam>
        /// <param name="sequence">Sequence on which to perform action</param>
        /// <param name="action">Action to perform on every item</param>
        /// <returns>IEnumerable&lt;TR&gt;.</returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static IEnumerable<TResult> ForEach<T, TResult>(this IEnumerable<T> sequence, Func<T, TResult> action)
        {
            IList<T> values = sequence as IList<T> ?? sequence.ToList();

            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            return values.Select(value => action(value)).ToList();
        }

        /// <summary>
        ///     Performs an action on each value of the sequence
        /// </summary>
        /// <typeparam name="T">Sequence element type.</typeparam>
        /// <param name="sequence">Sequence on which to perform action.</param>
        /// <param name="action">Action to perform on every item</param>
        /// <returns>IEnumerable&lt;V&gt;.</returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="System.ArgumentNullException"></exception>
        public static Task ForEach<T>(this IEnumerable<T> sequence, Func<T, Task> action)
        {
            IList<T> values = sequence as IList<T> ?? sequence.ToList();

            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            IEnumerable<Task> tasks = values.Select(value => action(value));
            return Task.WhenAll(tasks);
        }

        /// <summary>
        ///     Performs an action on each value of the sequence
        /// </summary>
        /// <typeparam name="T">Sequence element type.</typeparam>
        /// <typeparam name="TResult">Result element type.</typeparam>
        /// <param name="sequence">Sequence on which to perform action</param>
        /// <param name="action">Action to perform on every item</param>
        /// <returns>IEnumerable&lt;V&gt;.</returns>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="ArgumentNullException"></exception>
        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures")]
        public static async Task<IEnumerable<TResult>> ForEach<T, TResult>(this IEnumerable<T> sequence, Func<T, Task<TResult>> action)
        {
            IList<T> values = sequence as IList<T> ?? sequence.ToList();
            IList<TResult> results = new List<TResult>();

            if (sequence == null)
            {
                throw new ArgumentNullException(nameof(sequence));
            }

            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            foreach (T value in values)
            {
                results.Add(await action(value));
            }
            return results;
        }

        /// <summary>
        ///     Gets the length of the enumerable sequence.
        ///     When the value is a null reference, it is considered to have 0 elements.
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>System.Int32.</returns>
        public static int GetLength(this IEnumerable sequence)
        {
            // When the given enumerable is an ICollection, we can do a simple interface call to determine
            // it's size.
            if (sequence == null)
            {
                return 0;
            }

            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                return collection.Count;
            }

            // When we get at this point, we'll have to iterate over the enumerable to find out the size.
            IEnumerator enumerator = sequence.GetEnumerator();
            try
            {
                int count = 0;

                while (enumerator.MoveNext())
                {
                    count++;
                }

                return count;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                disposable?.Dispose();
            }
        }

        /// <summary>
        ///     Convenience method for retrieving a specific page of items within a collection.
        /// </summary>
        /// <typeparam name="T">Element type</typeparam>
        /// <param name="sequence">Sequence on which to perform action</param>
        /// <param name="pageIndex">The index of the page to get.</param>
        /// <param name="pageSize">The size of the pages.</param>
        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> sequence, int pageIndex, int pageSize)
        {
            IList<T> values = sequence as IList<T> ?? sequence.ToList();
            if (pageIndex < 0)
            {
                pageIndex = 0;
            }

            if (pageSize < 0)
            {
                pageSize = 0;
            }

            return values.Skip(pageIndex * pageSize).Take(pageSize);
        }

        /// <summary>
        ///     Validates that the <paramref name="enumerable" /> is not null and contains items.
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns>System.Boolean.</returns>
        public static bool IsNotNullOrEmpty<TSource>(this IEnumerable<TSource> enumerable)
        {
            return enumerable != null && enumerable.Any();
        }

        /// <summary>
        ///     Determines whether [is null or empty] [the specified sequence].
        /// </summary>
        /// <typeparam name="TSource">The type of the t source.</typeparam>
        /// <param name="sequence">The sequence.</param>
        /// <returns>System.Boolean.</returns>
        public static bool IsNullOrEmpty<TSource>(this IEnumerable<TSource> sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            ICollection<TSource> collection = sequence as ICollection<TSource>;

            if (collection != null)
            {
                // We expect this to be the normal flow.
                return collection.Count == 0;
            }

            // We expect this to be the exceptional flow, because most collections implement
            // ICollection<T>.
            return sequence.IsSequenceNullOrEmpty();
        }

        /// <summary>
        ///     Determines whether [is null or empty] [the specified sequence].
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>System.Boolean.</returns>
        public static bool IsNullOrEmpty(this IEnumerable sequence)
        {
            return sequence == null || sequence.IsSequenceNullOrEmpty();
        }

        /// <summary>
        ///     Concatenates the members of a collection, using the specified separator between each member.
        /// </summary>
        /// <returns>A string that consists of the members of <paramref name="values" /> delimited by the <paramref name="separator" /> string. If values has no members, the method returns null.</returns>
        public static string Join<T>(this IEnumerable<T> values, string separator = ",")
        {
            separator = separator ?? ",";
            return values == null ? null : string.Join(separator, values);
        }

        /// <summary>
        ///     Converts an sequence into a readonly collection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns>System.Collections.Generic.IEnumerable&lt;T&gt;.</returns>
        public static IEnumerable<T> ToReadOnlyCollection<T>(this IEnumerable<T> enumerable)
        {
            return new ReadOnlyCollection<T>(enumerable.ToList());
        }

        private static bool IsEnumerableEmpty(IEnumerable sequence)
        {
            IEnumerator enumerator = sequence.GetEnumerator();

            try
            {
                return !enumerator.MoveNext();
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                disposable?.Dispose();
            }
        }

        /// <summary>
        ///     Determines whether [is null or empty] [the specified sequence].
        /// </summary>
        /// <param name="sequence">The sequence.</param>
        /// <returns>System.Boolean.</returns>
        private static bool IsSequenceNullOrEmpty(this IEnumerable sequence)
        {
            if (sequence == null)
            {
                return true;
            }

            ICollection collection = sequence as ICollection;

            if (collection != null)
            {
                // We expect this to be the normal flow.
                return collection.Count == 0;
            }

            // We expect this to be the exceptional flow, because most collections implement ICollection.
            return IsEnumerableEmpty(sequence);
        }
    }
}