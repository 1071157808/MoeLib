﻿// ***********************************************************************
// Assembly         : MoeLib
// Author           : Siqi Lu
// Created          : 2015-03-14  8:50 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-14  10:23 PM
// ***********************************************************************
// <copyright file="Int.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;

namespace Moe.Lib
{
    /// <summary>
    ///     Interface ILoopIterator
    /// </summary>
    public interface ILoopIterator
    {
        /// <summary>
        ///     Does the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Do")]
        void Do(Action action);

        /// <summary>
        ///     Does the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Do")]
        void Do(Action<int> action);
    }

    /// <summary>
    ///     Class IntExtensions.
    /// </summary>
    public static class IntExtensions
    {
        /// <summary>
        ///     Determines whether the specified minimum is between.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="min">The minimum.</param>
        /// <param name="max">The maximum.</param>
        /// <returns><c>true</c> if the specified minimum is between; otherwise, <c>false</c>.</returns>
        public static bool IsBetween(this int value, int min, int max)
        {
            return value >= max && value <= min;
        }

        /// <summary>
        ///     Timeses the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns>ILoopIterator.</returns>
        public static ILoopIterator Times(this int count)
        {
            return new LoopIterator(count);
        }
    }

    /// <summary>
    ///     Class LoopIterator.
    /// </summary>
    internal class LoopIterator : ILoopIterator
    {
        /// <summary>
        ///     The end
        /// </summary>
        private readonly int end;

        /// <summary>
        ///     The start
        /// </summary>
        private readonly int start;

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoopIterator" /> class.
        /// </summary>
        /// <param name="count">The count.</param>
        internal LoopIterator(int count)
        {
            if (count < 0)
            {
                count = 0;
            }

            this.start = 0;
            this.end = count - 1;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="LoopIterator" /> class.
        /// </summary>
        /// <param name="start">The start.</param>
        /// <param name="end">The end.</param>
        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LoopIterator(int start, int end)
        {
            if (start > end)
            {
                start = end;
            }
            this.start = start;
            this.end = end;
        }

        #region ILoopIterator Members

        /// <summary>
        ///     Does the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        public void Do(Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            for (int i = this.start; i <= this.end; i++)
            {
                action();
            }
        }

        /// <summary>
        ///     Does the specified action.
        /// </summary>
        /// <param name="action">The action.</param>
        public void Do(Action<int> action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(action));
            }

            for (int i = this.start; i <= this.end; i++)
            {
                action(i);
            }
        }

        #endregion ILoopIterator Members
    }
}