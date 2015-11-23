using System;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Orleans.Diagnostics;
using MoeLib.Orleans;

namespace MoeLib.Jinyinmao.Orleans
{
    public abstract class JinyinmaoGrainBase : MoeGrainBase
    {
        private readonly Lazy<IOrleansLogger> logger = new Lazy<IOrleansLogger>(() => InitOrleansLogger());

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

        protected new IOrleansLogger GetLogger(string loggerName)
        {
            return this.GetLogger();
        }

        private static IOrleansLogger InitOrleansLogger()
        {
            return App.LogManager.CreateOrleansLogger();
        }
    }
}