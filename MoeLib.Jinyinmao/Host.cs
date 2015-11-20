using System;

namespace MoeLib.Jinyinmao
{
    /// <summary>
    ///     Host.
    /// </summary>
    public class Host
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Host" /> class.
        /// </summary>
        internal Host()
        {
        }

        /// <summary>
        ///     Gets or sets the application keys.
        /// </summary>
        /// <value>The application keys.</value>
        public string AppKeys { get; set; }

        /// <summary>
        ///     Gets or sets the deployment identifier.
        /// </summary>
        /// <value>The deployment identifier.</value>
        public Guid DeploymentId { get; set; }

        /// <summary>
        ///     Gets or sets the role.
        /// </summary>
        /// <value>The role.</value>
        public string Role { get; set; }

        /// <summary>
        ///     Gets or sets the role instance.
        /// </summary>
        /// <value>The role instance.</value>
        public string RoleInstance { get; set; }
    }
}