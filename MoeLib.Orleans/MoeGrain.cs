// ***********************************************************************
// Project          : MoeLib
// File             : MoeGrain.cs
// Created          : 2015-11-25  1:40 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  2:24 PM
// ***********************************************************************
// <copyright file="MoeGrain.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime;

namespace MoeLib.Orleans
{
    /// <summary>
    ///     MoeGrain.
    /// </summary>
    public class MoeGrain : Grain, IMoeGrain
    {
        private readonly MoeGrainBase moeGrainBase = new MoeGrainBase();

        #region IMoeGrain Members

        /// <summary>
        ///     Get a previously registered reminder or registers a new persistent, reliable reminder to send regular notifications (reminders) to the MoeGrainBase.
        ///     The MoeGrainBase must implement the <c>Orleans.IRemindable</c> interface, and reminders for this MoeGrainBase will be sent to the <c>ReceiveReminder</c> callback method.
        ///     If the current MoeGrainBase is deactivated when the timer fires, a new activation of this MoeGrainBase will be created to receive this reminder.
        ///     If an existing reminder with the same name already exists, that reminder will be overwritten with this new reminder.
        ///     Reminders will always be received by one activation of this MoeGrainBase, even if multiple activations exist for this MoeGrainBase.
        /// </summary>
        /// <param name="reminderName">Name of this reminder</param>
        /// <param name="dueTime">Due time for this reminder</param>
        /// <param name="period">Frequence period for this reminder</param>
        /// <returns>Promise for Reminder handle.</returns>
        public Task<IGrainReminder> GetOrRegisterReminder(string reminderName, TimeSpan dueTime, TimeSpan period)
        {
            return this.moeGrainBase.GetOrRegisterReminder(reminderName, dueTime, period);
        }

        /// <summary>
        ///     Unregisters a previously registered reminder or do nothing if the reminder has not been registered.
        /// </summary>
        /// <param name="reminderName">Name of the reminder to unregister.</param>
        /// <returns>Completion promise for this operation.</returns>
        public Task UnregisterReminder(string reminderName)
        {
            return this.moeGrainBase.UnregisterReminder(reminderName);
        }

        #endregion IMoeGrain Members
    }

    /// <summary>
    ///     MoeGrain.
    /// </summary>
    /// <typeparam name="TGrainState">The type of the t grain state.</typeparam>
    public class MoeGrain<TGrainState> : Grain<TGrainState>, IMoeGrain where TGrainState : GrainState
    {
        private readonly MoeGrainBase moeGrainBase = new MoeGrainBase();

        #region IMoeGrain Members

        /// <summary>
        ///     Get a previously registered reminder or registers a new persistent, reliable reminder to send regular notifications (reminders) to the MoeGrainBase.
        ///     The MoeGrainBase must implement the <c>Orleans.IRemindable</c> interface, and reminders for this MoeGrainBase will be sent to the <c>ReceiveReminder</c> callback method.
        ///     If the current MoeGrainBase is deactivated when the timer fires, a new activation of this MoeGrainBase will be created to receive this reminder.
        ///     If an existing reminder with the same name already exists, that reminder will be overwritten with this new reminder.
        ///     Reminders will always be received by one activation of this MoeGrainBase, even if multiple activations exist for this MoeGrainBase.
        /// </summary>
        /// <param name="reminderName">Name of this reminder</param>
        /// <param name="dueTime">Due time for this reminder</param>
        /// <param name="period">Frequence period for this reminder</param>
        /// <returns>Promise for Reminder handle.</returns>
        public Task<IGrainReminder> GetOrRegisterReminder(string reminderName, TimeSpan dueTime, TimeSpan period)
        {
            return this.moeGrainBase.GetOrRegisterReminder(reminderName, dueTime, period);
        }

        /// <summary>
        ///     Unregisters a previously registered reminder or do nothing if the reminder has not been registered.
        /// </summary>
        /// <param name="reminderName">Name of the reminder to unregister.</param>
        /// <returns>Completion promise for this operation.</returns>
        public Task UnregisterReminder(string reminderName)
        {
            return this.moeGrainBase.UnregisterReminder(reminderName);
        }

        #endregion IMoeGrain Members
    }
}