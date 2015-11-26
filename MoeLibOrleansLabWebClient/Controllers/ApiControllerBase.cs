// ***********************************************************************
// Project          : MoeLib
// File             : ApiControllerBase.cs
// Created          : 2015-11-23  5:22 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  1:03 AM
// ***********************************************************************
// <copyright file="ApiControllerBase.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Web;
using MoeLib.Jinyinmao.Web;
using Orleans;
using Orleans.Runtime.Configuration;

namespace MoeLibOrleansLabWebClient.Controllers
{
    public abstract class ApiControllerBase : JinyinmaoApiController
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiControllerBase" /> class.
        /// </summary>
        protected ApiControllerBase()
        {
            if (GrainClient.IsInitialized)
            {
                return;
            }

            string configFilePath = HttpContext.Current.Server.MapPath(@"~/ClientConfiguration.xml");
            ClientConfiguration clientConfiguration = ClientConfiguration.LoadFromFile(configFilePath);
            GrainClient.Initialize(clientConfiguration);
        }
    }
}