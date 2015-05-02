﻿// ***********************************************************************
// Project          : MoeLib
// Author           : Siqi Lu
// Created          : 2015-05-02  11:21 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-05-02  11:47 PM
// ***********************************************************************
// <copyright file="PaginatedList.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Moe.Lib
{
    /// <summary>
    ///     PaginatedList.
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    public class PaginatedList<TEntity> : List<TEntity>, IPaginatedList<TEntity>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PaginatedList{TEntity}" /> class.
        /// </summary>
        public PaginatedList()
        {
            this.Items = new List<TEntity>();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PaginatedList{TEntity}" /> class.
        /// </summary>
        /// <param name="pageIndex">Index of the page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="totalCount">The total count.</param>
        /// <param name="source">The source.</param>
        public PaginatedList(int pageIndex, int pageSize, int totalCount, IEnumerable<TEntity> source)
        {
            this.AddRange(source);

            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.TotalCount = totalCount;
            this.TotalPageCount = (int)Math.Ceiling(totalCount / (double)pageSize);
        }

        #region IPaginatedList<TEntity> Members

        /// <summary>
        ///     Gets a value indicating whether this instance has next page.
        /// </summary>
        /// <value><c>true</c> if this instance has next page; otherwise, <c>false</c>.</value>
        public bool HasNextPage
        {
            get { return this.PageIndex < this.TotalPageCount; }
        }

        /// <summary>
        ///     Gets the items.
        /// </summary>
        /// <value>The items.</value>
        public IEnumerable<TEntity> Items
        {
            get { return this; }
            set
            {
                this.Clear();
                this.AddRange(value);
            }
        }

        /// <summary>
        ///     Gets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
        public int PageIndex { get; private set; }

        /// <summary>
        ///     Gets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
        public int PageSize { get; private set; }

        /// <summary>
        ///     Gets the total count.
        /// </summary>
        /// <value>The total count.</value>
        [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
        public int TotalCount { get; private set; }

        /// <summary>
        ///     Gets the total page count.
        /// </summary>
        /// <value>The total page count.</value>
        [SuppressMessage("ReSharper", "AutoPropertyCanBeMadeGetOnly.Local")]
        public int TotalPageCount { get; private set; }

        #endregion IPaginatedList<TEntity> Members

        /// <summary>
        ///     Convert to another paginated list.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="selector">The selector.</param>
        /// <returns>IPaginatedList&lt;T&gt;.</returns>
        public IPaginatedList<T> ToPaginated<T>(Func<TEntity, T> selector)
        {
            return new PaginatedList<T>(this.PageIndex, this.PageSize, this.TotalCount, this.Items.Select(selector));
        }
    }

    /// <summary>
    ///     Interface IPaginatedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPaginatedList<out T>
    {
        /// <summary>
        ///     Gets a value indicating whether this instance has next page.
        /// </summary>
        /// <value><c>true</c> if this instance has next page; otherwise, <c>false</c>.</value>
        bool HasNextPage { get; }

        /// <summary>
        ///     Gets the items.
        /// </summary>
        /// <value>The items.</value>
        IEnumerable<T> Items { get; }

        /// <summary>
        ///     Gets the index of the page.
        /// </summary>
        /// <value>The index of the page.</value>
        int PageIndex { get; }

        /// <summary>
        ///     Gets the size of the page.
        /// </summary>
        /// <value>The size of the page.</value>
        int PageSize { get; }

        /// <summary>
        ///     Gets the total count.
        /// </summary>
        /// <value>The total count.</value>
        int TotalCount { get; }

        /// <summary>
        ///     Gets the total page count.
        /// </summary>
        /// <value>The total page count.</value>
        int TotalPageCount { get; }
    }
}