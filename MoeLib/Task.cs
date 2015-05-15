// ***********************************************************************
// Project          : MoeLib
// Author           : Siqi Lu
// Created          : 2015-05-15  10:43 AM
//
// Last Modified By : Siqi Lu
// Last Modified On : 2015-05-15  11:05 AM
// ***********************************************************************
// <copyright file="Task.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Threading.Tasks;

namespace Moe.Lib
{
    /// <summary>
    ///     TaskEx.
    /// </summary>
    public static class TaskEx
    {
        /// <summary>
        ///     Forgets the specified task.
        /// </summary>
        /// <param name="task">The task.</param>
        /// <param name="exceptionHandler">The exception handler.</param>
        public static async void Forget(this Task task, Action<Exception> exceptionHandler = null)
        {
            try
            {
                await task.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                if (exceptionHandler == null)
                    throw;
                exceptionHandler.Invoke(e);
            }
        }
    }
}