using System;

namespace MoeLib.Jinyinmao.Config
{
    /// <summary>
    ///     GovernmentServerConfigProvider.
    /// </summary>
    /// <typeparam name="TConfig">The type of the t configuration.</typeparam>
    public class GovernmentServerConfigProvider<TConfig> : IConfigProvider<TConfig> where TConfig : class, new()
    {
        #region IConfigProvider<TConfig> Members

        /// <summary>
        ///     Gets the configuration.
        /// </summary>
        /// <returns>TConfig.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public TConfig GetConfig()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the configuration json string.
        /// </summary>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public string GetConfigJsonString()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Gets the type of the configuration.
        /// </summary>
        /// <returns>Type.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Type GetConfigType()
        {
            throw new NotImplementedException();
        }

        #endregion IConfigProvider<TConfig> Members
    }
}