using System;

namespace MoeLib.Jinyinmao
{
    /// <summary>
    ///     Interface IAppConfigProvider
    /// </summary>
    public interface IAppConfigProvider
    {
        /// <summary>
        ///     Gets the application keys configuration.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetAppKeysConfig();

        /// <summary>
        ///     Gets the deployment identifier configuration.
        /// </summary>
        /// <returns>Guid.</returns>
        Guid GetDeploymentIdConfig();

        /// <summary>
        ///     Gets the role configuration.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetRoleConfig();

        /// <summary>
        ///     Gets the role instance configuration.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetRoleInstanceConfig();
    }
}