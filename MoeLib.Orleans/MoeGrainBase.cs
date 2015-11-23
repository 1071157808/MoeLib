using System;
using System.Threading.Tasks;
using Orleans;
using Orleans.Runtime;

namespace MoeLib.Orleans
{
    /// <summary>
    ///     MoeGrainBaseExtensions.
    /// </summary>
    public static class MoeGrainBaseExtensions
    {
        /// <summary>
        ///     Get a previously registered reminder or registers a new persistent, reliable reminder to send regular notifications (reminders) to the MoeGrainBase.
        ///     The MoeGrainBase must implement the <c>Orleans.IRemindable</c> interface, and reminders for this MoeGrainBase will be sent to the <c>ReceiveReminder</c> callback method.
        ///     If the current MoeGrainBase is deactivated when the timer fires, a new activation of this MoeGrainBase will be created to receive this reminder.
        ///     If an existing reminder with the same name already exists, that reminder will be overwritten with this new reminder.
        ///     Reminders will always be received by one activation of this MoeGrainBase, even if multiple activations exist for this MoeGrainBase.
        /// </summary>
        /// <param name="moeGrainBase">The instance of <see cref="MoeGrainBase" />.</param>
        /// <param name="reminderName">Name of this reminder</param>
        /// <param name="dueTime">Due time for this reminder</param>
        /// <param name="period">Frequence period for this reminder</param>
        /// <returns>Promise for Reminder handle.</returns>
        public static Task<IGrainReminder> GetOrRegisterReminder(this MoeGrainBase moeGrainBase, string reminderName, TimeSpan dueTime, TimeSpan period)
        {
            return moeGrainBase.GetOrRegisterReminder(reminderName, dueTime, period);
        }

        /// <summary>
        ///     Unregisters a previously registered reminder or do nothing if the reminder has not been registered.
        /// </summary>
        /// <param name="moeGrainBase">The instance of <see cref="MoeGrainBase" />.</param>
        /// <param name="reminderName">Name of the reminder to unregister.</param>
        /// <returns>Completion promise for this operation.</returns>
        public static Task UnregisterReminder(this MoeGrainBase moeGrainBase, string reminderName)
        {
            return moeGrainBase.UnregisterReminder(reminderName);
        }
    }

    /// <summary>
    ///     MoeGrainBase.
    /// </summary>
    public abstract class MoeGrainBase : Grain
    {
        /// <summary>
        ///     Gets the grain factory.
        /// </summary>
        /// <value>The grain factory.</value>
        public new IGrainFactory GrainFactory
        {
            get { return base.GrainFactory; }
        }

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
        public async Task<IGrainReminder> GetOrRegisterReminder(string reminderName, TimeSpan dueTime, TimeSpan period)
        {
            return await this.GetReminder(reminderName) ?? await this.RegisterOrUpdateReminder(reminderName, dueTime, period);
        }

        /// <summary>
        ///     Unregisters a previously registered reminder or do nothing if the reminder has not been registered.
        /// </summary>
        /// <param name="reminderName">Name of the reminder to unregister.</param>
        /// <returns>Completion promise for this operation.</returns>
        public async Task UnregisterReminder(string reminderName)
        {
            IGrainReminder reminder = await this.GetReminder(reminderName);

            if (reminder != null)
            {
                await this.UnregisterReminder(reminder);
            }
        }
    }
}