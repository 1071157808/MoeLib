using System;

namespace MoeLib.Jinyinmao.Configs
{
    /// <summary>
    ///     Interface IConfigProvider
    /// </summary>
    /// <typeparam name="TConfig">The type of the t configuration.</typeparam>
    public interface IConfigProvider<out TConfig> where TConfig : class, new()
    {
        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <returns>TConfig.</returns>
        TConfig GetConfig();

        /// <summary>
        ///     Gets the configuration json string.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetConfigJsonString();

        /// <summary>
        ///     Gets the type of the configuration.
        /// </summary>
        /// <returns>Type.</returns>
        Type GetConfigType();
    }
}