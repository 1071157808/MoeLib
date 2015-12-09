﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
using MoeLib.Diagnostics;

namespace MoeLib.Jinyinmao.Web.Diagnostics
{
    /// <summary>
    ///     JinyinmaoLogHandler.
    /// </summary>
    public class JinyinmaoLogHandler : DelegatingHandler
    {
        /// <summary>
        ///     The logger
        /// </summary>
        private static readonly Lazy<IWebLogger> logger = new Lazy<IWebLogger>(() => InitApplicationLogger());

        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoLogHandler" /> class.
        /// </summary>
        public JinyinmaoLogHandler(string requestTag, string responseTag)
        {
            this.RequestTag = requestTag;
            this.ResponseTag = responseTag;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoLogHandler" /> class.
        /// </summary>
        public JinyinmaoLogHandler()
        {
            this.RequestTag = "ASP.NET HTTP Request";
            this.ResponseTag = "ASP.NET HTTP Response";
        }

        /// <summary>
        ///     Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        private IWebLogger Logger
        {
            get { return logger.Value; }
        }

        private string RequestTag { get; set; }

        private string ResponseTag { get; set; }

        /// <summary>
        ///     Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <returns>
        ///     Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.
        /// </returns>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="request" /> was null.</exception>
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            TraceEntry traceEntry = request?.GetTraceEntry();

            string requestIdString = traceEntry?.RequestId ?? Guid.NewGuid().ToGuidString();

            this.Logger.Info($"Request Begin: {requestIdString}", request, this.RequestTag, 0UL, string.Empty, traceEntry);

            HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

            Dictionary<string, object> payload = new Dictionary<string, object>
            {
                { "ResponseStatusCode", response.StatusCode }
            };

            if (response.Content != null && response.Content.Headers.ContentType.MediaType.StartsWith("application", StringComparison.OrdinalIgnoreCase))
            {
                payload.Add("ResponseContent", (await response.Content.ReadAsStringAsync()).GetFirst(30000));
            }

            this.Logger.Info($"Request End: {requestIdString}", request, this.ResponseTag, 0UL, string.Empty, traceEntry, null, payload);

            return response;
        }

        private static IWebLogger InitApplicationLogger()
        {
            return App.LogManager.CreateWebLogger();
        }
    }
}