using System;
using System.Threading.Tasks;
using Moe.Lib;
using MoeLib.Jinyinmao.Orleans;
using MoeLibOrleansLabIGrain;

namespace MoeLibOrleansLabGrains
{
    /// <summary>
    ///     LogGrain.
    /// </summary>
    public class LogGrain : JinyinmaoGrainBase, ILogGrain
    {
        #region ILogGrain Members

        public Task<string> ExceptionAsync()
        {
            throw new ApplicationException("This is for testing exception logger",
                new ApplicationException("This is the first inner exception.", new ApplicationException("This is the second inner exception.")));
        }

        public Task<string> TraceAsync()
        {
            this.Verbose("This is the log message of Debug level.");
            this.Info("This is the log message of Info level.");
            this.Warning("This is the log message of Warn level.");
            this.Error("This is the log message of Error level.");
            this.Critical("This is the log message of Fatal level.");

            this.Verbose("This is the exception log message of Debug level.", new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")));
            this.Info("This is the exception log message of Info level.", new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")));
            this.Warning("This is the exception log message of Warn level.", new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")));
            this.Error("This is the exception log message of Error level.", new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")));
            this.Critical("This is the exception log message of Fatal level.", new ApplicationException("This is the outer exception.", new ApplicationException("This is the inner exception.")));

            return Task.FromResult("Hello from " + HostServer.IP);
        }

        #endregion ILogGrain Members
    }
}