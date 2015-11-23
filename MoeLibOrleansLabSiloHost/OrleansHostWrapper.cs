/*
Project Orleans Cloud Service SDK ver. 1.0

Copyright (c) Microsoft Corporation

All rights reserved.

MIT License

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
associated documentation files (the ""Software""), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense,
and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so,
subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED *AS IS*, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO
THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS
OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Net;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Azure;
using MoeLib.Jinyinmao.Web.Diagnostics;
using Orleans.Runtime;
using Orleans.Runtime.Host;

namespace MoeLibOrleansLabSiloHost
{
    /// <summary>
    ///     OrleansHostWrapper.
    /// </summary>
    internal sealed class OrleansHostWrapper : IDisposable
    {
        private SiloHost siloHost;

        public OrleansHostWrapper(IEnumerable<string> args)
        {
            this.ParseArguments(args);
            this.Init();
        }

        public bool Debug
        {
            get { return this.siloHost != null && this.siloHost.Debug; }
            set { this.siloHost.Debug = value; }
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.Dispose(true);
        }

        #endregion IDisposable Members

        public void PrintUsage()
        {
            Console.WriteLine(
                @"USAGE:
    orleans host [<siloName> [<configFile>]] [DeploymentId=<idString>] [/debug]
Where:
    <siloName>      - Name of this silo in the Config file list (optional)
    <configFile>    - Path to the Config file to use (optional)
    DeploymentId=<idString>
                    - Which deployment group this host instance should run in (optional)");
        }

        public bool Run()
        {
            bool ok = false;

            try
            {
                #region 日志配置

                App.Initialize().ConfigWithAzure();

                TraceLogger.LogConsumers.Add(new JinyinmaoSiloTraceWriter());

                #endregion 日志配置

                this.siloHost.InitializeOrleansSilo();

                ok = this.siloHost.StartOrleansSilo();

                if (ok)
                {
                    Console.WriteLine($"Successfully started Orleans silo '{this.siloHost.Name}' as a {this.siloHost.Type} node.");
                }
                else
                {
                    throw new SystemException($"Failed to start Orleans silo '{this.siloHost.Name}' as a {this.siloHost.Type} node.");
                }
            }
            catch (Exception exc)
            {
                this.siloHost.ReportStartupError(exc);
                string msg = $"{exc.GetType().FullName}:\n{exc.Message}\n{exc.StackTrace}";
                Console.WriteLine(msg);
            }

            return ok;
        }

        public bool Stop()
        {
            try
            {
                this.siloHost.StopOrleansSilo();

                Console.WriteLine($"Orleans silo '{this.siloHost.Name}' shutdown.");
            }
            catch (Exception exc)
            {
                this.siloHost.ReportStartupError(exc);
                string msg = $"{exc.GetType().FullName}:\n{exc.Message}\n{exc.StackTrace}";
                Console.WriteLine(msg);
            }

            return false;
        }

        private void Dispose(bool dispose)
        {
            this.siloHost.Dispose();
            this.siloHost = null;
        }

        private void Init()
        {
            this.siloHost.LoadOrleansConfig();
        }

        private bool ParseArguments(IEnumerable<string> args)
        {
            string deploymentId = null;

            string configFileName = "DevTestServerConfiguration.xml";
            string siloName = Dns.GetHostName(); // Default to machine name

            int argPos = 1;
            foreach (string a in args)
            {
                if (a.StartsWith("-", StringComparison.Ordinal) || a.StartsWith("/", StringComparison.Ordinal))
                {
                    switch (a.ToLowerInvariant())
                    {
                        case "/?":
                        case "/help":
                        case "-?":
                        case "-help":
                            // Query usage help
                            return false;

                        default:
                            Console.WriteLine("Bad command line arguments supplied: " + a);
                            return false;
                    }
                }
                if (a.Contains("="))
                {
                    string[] split = a.Split('=');
                    if (string.IsNullOrEmpty(split[1]))
                    {
                        Console.WriteLine("Bad command line arguments supplied: " + a);
                        return false;
                    }
                    switch (split[0].ToLowerInvariant())
                    {
                        case "deploymentid":
                            deploymentId = split[1];
                            break;

                        case "deploymentgroup":
                            // TODO: Remove this at some point in future
                            Console.WriteLine("Ignoring deprecated command line argument: " + a);
                            break;

                        default:
                            Console.WriteLine("Bad command line arguments supplied: " + a);
                            return false;
                    }
                }
                // unqualified arguments below
                else
                    switch (argPos)
                    {
                        case 1:
                            siloName = a;
                            argPos++;
                            break;

                        case 2:
                            configFileName = a;
                            argPos++;
                            break;

                        default:
                            // Too many command line arguments
                            Console.WriteLine("Too many command line arguments supplied: " + a);
                            return false;
                    }
            }

            this.siloHost = new SiloHost(siloName)
            {
                ConfigFileName = configFileName
            };

            if (deploymentId != null)
                this.siloHost.DeploymentId = deploymentId;

            return true;
        }
    }
}