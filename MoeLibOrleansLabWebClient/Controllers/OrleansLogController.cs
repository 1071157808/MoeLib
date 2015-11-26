// ***********************************************************************
// Project          : MoeLib
// File             : OrleansLogController.cs
// Created          : 2015-11-23  5:22 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-27  1:03 AM
// ***********************************************************************
// <copyright file="OrleansLogController.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System;
using System.Threading.Tasks;
using System.Web.Http;
using MoeLib.Jinyinmao.Orleans;
using MoeLibOrleansLabIGrain;
using Orleans;

namespace MoeLibOrleansLabWebClient.Controllers
{
    [RoutePrefix("Log")]
    public class OrleansLogController : ApiControllerBase
    {
        [HttpGet, Route("Exception")]
        public async Task<IHttpActionResult> GetException()
        {
            ILogGrain logGrain = GrainClient.GrainFactory.GetGrain<ILogGrain>(Guid.NewGuid());
            return this.Ok(await logGrain.WithTraceEntry(this.Request).ExceptionAsync());
        }

        [HttpGet, Route("Trace")]
        public async Task<IHttpActionResult> GetTrace()
        {
            ILogGrain logGrain = GrainClient.GrainFactory.GetGrain<ILogGrain>(Guid.NewGuid());
            return this.Ok(await logGrain.WithTraceEntry(this.Request).TraceAsync());
        }
    }
}