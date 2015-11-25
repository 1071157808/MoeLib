// ***********************************************************************
// Project          : MoeLib
// File             : LogGrain.cs
// Created          : 2015-11-20  8:47 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  2:11 PM
// ***********************************************************************
// <copyright file="LogGrain.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

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
    public class LogGrain : JinyinmaoGrain, ILogGrain
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