// ***********************************************************************
// Assembly         : MoeEnsure
// Author           : Siqi Lu
// Created          : 2015-03-15  2:52 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-22  11:27 PM
// ***********************************************************************
// <copyright file="Ensures.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Diagnostics.CodeAnalysis;

namespace Moe.Lib
{
    /// <summary>
    ///     Ensures
    /// </summary>
    /// <typeparam name="T">The type of ensure object</typeparam>
    public class Ensures<T>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Ensures{T}" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public Ensures(T value)
        {
            this.Value = value;
            this.Result = false;
        }

        /// <summary>
        ///     Gets a value indicating whether this <see cref="Ensures{T}" /> is result.
        /// </summary>
        /// <value><c>true</c> if result; otherwise, <c>false</c>.</value>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public bool Result { get; private set; }

        /// <summary>
        ///     Gets the value.
        /// </summary>
        /// <value>The value.</value>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public T Value { get; }

        /// <summary>
        ///     Ensures given condition is false
        /// </summary>
        /// <param name="condition">Condition to test</param>
        /// <returns>Ensures&lt;T&gt;.</returns>
        /// <remarks>The ensure result would be set into the Result property of the instance.</remarks>
        public Ensures<T> Not(Func<T, bool> condition)
        {
            this.Result = !condition.Invoke(this.Value);
            return this;
        }

        /// <summary>
        ///     Ensures that the given expression is true
        /// </summary>
        /// <param name="condition">Condition to test/ensure</param>
        /// <returns>Ensures instance.</returns>
        /// <remarks>The ensure result would be set into the Result property of the instance.</remarks>
        public Ensures<T> That(Func<T, bool> condition)
        {
            this.Result = condition.Invoke(this.Value);
            return this;
        }

        /// <summary>
        ///     Ensures that the given expression is true
        /// </summary>
        /// <param name="condition">Condition to test/ensure</param>
        /// <returns>Ensures instance.</returns>
        /// <remarks>The ensure result would be set into the Result property of the instance.</remarks>
        public Ensures<T> That(Func<bool> condition)
        {
            this.Result = condition.Invoke();
            return this;
        }

        /// <summary>
        ///     Throw the exception when the result is false.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <returns><c>true</c> if the Result is true, <c>throw a TException</c> otherwise.</returns>
        public bool WithException<TException>() where TException : Exception
        {
            if (this.Result != true)
            {
                throw (TException)Activator.CreateInstance(typeof(TException));
            }

            return this.Result;
        }

        /// <summary>
        ///     Throw the exception when the result is false.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="exception">The exception to throw.</param>
        /// <returns><c>true</c> if the Result is true, <c>throw a TException</c> otherwise.</returns>
        public bool WithException<TException>(TException exception) where TException : Exception
        {
            if (this.Result != true)
            {
                throw exception;
            }

            return this.Result;
        }

        /// <summary>
        ///     Throw the exception when the result is false.
        /// </summary>
        /// <typeparam name="TException">The type of the exception.</typeparam>
        /// <param name="message">The exception message.</param>
        /// <param name="formates">The formates.</param>
        /// <returns><c>true</c> if the Result is true, <c>throw a TException</c> otherwise.</returns>
        public bool WithException<TException>(string message, params object[] formates) where TException : Exception
        {
            if (this.Result != true)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message.FormatWith(formates));
            }

            return this.Result;
        }
    }
}