// ***********************************************************************
// Assembly         : MoeEnsure
// Author           : Siqi Lu
// Created          : 2015-03-15  2:52 PM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-03-22  11:27 PM
// ***********************************************************************
// <copyright file="It.cs" company="Shanghai Yuyi">
//     Copyright ©  2012-2015 Shanghai Yuyi. All rights reserved.
// </copyright>
// ***********************************************************************

namespace Moe.Lib
{
    /// <summary>
    ///     Use It class to construct Ensures instance.
    /// </summary>
    public static class It
    {
        /// <summary>
        ///     Ensures the specified value.
        /// </summary>
        /// <typeparam name="T">Type of the value.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>Ensures instance.</returns>
        public static Ensures<T> Ensures<T>(T value)
        {
            return new Ensures<T>(value);
        }

        /// <summary>
        ///     Ensures.
        /// </summary>
        /// <returns>Ensures instance.</returns>
        public static Ensures<object> Ensures()
        {
            return new Ensures<object>(new object());
        }
    }
}
