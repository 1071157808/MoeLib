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
using System.Threading.Tasks;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
using MoeLib.Diagnostics;
using MoeLib.Jinyinmao.Configs;
using MoeLib.Jinyinmao.Web;

namespace MoeLibLab
{
    public class DispatcherRequest
    {
        public string BizCode { get; set; }

        public string ChannelCode { get; set; }

        public List<int> Gateway { get; set; }

        public int MessageType
        {
            get { return 10; }
        }

        public string Priority { get; set; }

        public string SendRule { get; set; }

        public Dictionary<string, string> TemplateParams { get; set; }

        public List<UserInfo> UserInfoList { get; set; }
    }

    public class TestConfig : IConfig
    {
        #region IConfig Members

        /// <summary>
        ///     Gets the ip whitelists.
        /// </summary>
        /// <value>The ip whitelists.</value>
        public List<string> IPWhitelists { get; set; }

        /// <summary>
        ///     Gets the resources.
        /// </summary>
        /// <value>The resources.</value>
        public Dictionary<string, string> Resources { get; set; }

        #endregion IConfig Members
    }

    public class UserInfo
    {
        public string Email { get; set; }

        public string PhoneNum { get; set; }

        public string UAppId { get; set; }

        public string UId { get; set; }

        public string WeChatNum { get; set; }
    }

    internal class JinyinmaoConfig : IConfig
    {
        #region IConfig Members

        /// <summary>
        ///     Gets the ip whitelists.
        /// </summary>
        /// <value>The ip whitelists.</value>
        public List<string> IPWhitelists { get; set; }

        /// <summary>
        ///     Gets the resources.
        /// </summary>
        /// <value>The resources.</value>
        public Dictionary<string, string> Resources { get; set; }

        #endregion IConfig Members
    }

    internal class Program
    {
        public static string TestTask()
        {
            return Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(60));
                return "aaa";
            }).Result;
        }

        private static void Main(string[] args)
        {
            List<string> list = "{}".FromJson<JinyinmaoConfig>().IPWhitelists;
            Console.WriteLine(list?.Count);
        }

        private static async Task Test()
        {
            App.Initialize().Config().UseGovernmentServerConfigManager<TestConfig>();

            using (HttpClient client = JYMInternalHttpClientFactory.Create("Jinyinmao.MessageManager.Api", (TraceEntry)null))
            {
                HttpResponseMessage response = await client.PostAsJsonAsync("/api/MessageManager/SendWithTemplate", new DispatcherRequest());
                string content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(content);
            }
        }
    }
}