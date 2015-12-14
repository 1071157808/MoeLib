// ***********************************************************************
// Project          : MoeLib
// File             : Program.cs
// Created          : 2015-11-20  5:55 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-28  6:55 PM
// ***********************************************************************
// <copyright file="Program.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Net.Http;
using Moe.Lib.Jinyinmao;
using MoeLib.Diagnostics;
using MoeLib.Jinyinmao.Configs;
using MoeLib.Jinyinmao.Web;

namespace MoeLibLab
{
    public class TestConfig : IConfig
    {
        #region IConfig Members

        /// <summary>
        ///     Gets the resources.
        /// </summary>
        /// <value>The resources.</value>
        public Dictionary<string, string> Resources { get; set; }

        #endregion IConfig Members
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            App.Initialize().Config().UseGovernmentServerConfigManager<TestConfig>();

            using (HttpClient client = JYMInternalHttpClientFactory.Create("Jinyinmao.MessageManager.Api", (TraceEntry)null))
            {
                client.GetAsync("/api/a").Wait();
                Console.WriteLine("1");
            }
        }
    }
}