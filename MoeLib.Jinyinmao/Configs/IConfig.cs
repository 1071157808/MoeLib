using System.Collections.Generic;

namespace MoeLib.Jinyinmao.Configs
{
    /// <summary>
    ///     Interface IConfig
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        ///     Gets the configurations.
        /// </summary>
        /// <value>The configurations.</value>
        string Configurations { get; }

        /// <summary>
        ///     Gets the configuration version.
        /// </summary>
        /// <value>The configuration version.</value>
        string ConfigurationVersion { get; }

        /// <summary>
        ///     Gets the permissions.
        /// </summary>
        /// <value>The permissions.</value>
        Dictionary<string, KeyValuePair<string, string>> Permissions { get; }

        /// <summary>
        ///     Gets the resources.
        /// </summary>
        /// <value>The resources.</value>
        Dictionary<string, string> Resources { get; }
    }

    /// <summary>
    ///     Interface IConfig
    /// </summary>
    /// <typeparam name="TConfig"></typeparam>
    public interface IConfig<out TConfig> : IConfig where TConfig : class
    {
        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        TConfig Config { get; }
    }
}