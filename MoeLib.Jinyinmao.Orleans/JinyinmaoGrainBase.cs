using System;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Orleans.Diagnostics;
using MoeLib.Orleans;

namespace MoeLib.Jinyinmao.Orleans
{
    /// <summary>
    ///     JinyinmaoGrainBase.
    /// </summary>
    public abstract class JinyinmaoGrainBase : MoeGrainBase
    {
        /// <summary>
        ///     The logger
        /// </summary>
        private readonly Lazy<IOrleansLogger> logger = new Lazy<IOrleansLogger>(() => InitOrleansLogger());

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        public IOrleansLogger Logger
        {
            get { return this.logger.Value; }
        }

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <returns>IOrleansLogger.</returns>
        protected new IOrleansLogger GetLogger()
        {
            return this.Logger;
        }

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns>IOrleansLogger.</returns>
        protected new IOrleansLogger GetLogger(string loggerName)
        {
            return this.GetLogger();
        }

        /// <summary>
        ///     Initializes the orleans logger.
        /// </summary>
        /// <returns>IOrleansLogger.</returns>
        private static IOrleansLogger InitOrleansLogger()
        {
            return App.LogManager.CreateOrleansLogger();
        }
    }
}