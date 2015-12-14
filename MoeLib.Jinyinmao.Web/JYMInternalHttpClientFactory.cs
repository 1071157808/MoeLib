using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Moe.Lib;
using MoeLib.Diagnostics;
using MoeLib.Jinyinmao.Web.Diagnostics;
using MoeLib.Jinyinmao.Web.Handlers;
using MoeLib.Jinyinmao.Web.Handlers.Client;

namespace MoeLib.Jinyinmao.Web
{
    /// <summary>
    ///     JYMHttpClient.
    /// </summary>
    public static class JYMInternalHttpClientFactory
    {
        /// <summary>
        ///     Creates a new instance of the <see cref="T:System.Net.Http.HttpClient" />.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="handlers">The list of HTTP handler that delegates the processing of HTTP response messages to another handler.</param>
        /// <returns>A new instance of the <see cref="T:System.Net.Http.HttpClient" />.</returns>
        public static HttpClient Create(string serviceName, TraceEntry traceEntry, params DelegatingHandler[] handlers)
        {
            IList<DelegatingHandler> delegatingHandlers = new List<DelegatingHandler>();
            delegatingHandlers.Add(new JinyinmaoServicePermissionHandler(serviceName));
            delegatingHandlers.Add(new JinyinmaoTraceEntryHandler(traceEntry));
            delegatingHandlers.Add(new JinyinmaoHttpStatusHandler());
            delegatingHandlers.Add(new JinyinmaoLogHandler("HTTP Client Request", "HTTP Client Response"));
            delegatingHandlers.Add(new JinyinmaoRetryHandler());

            HttpClient client = HttpClientFactory.Create(new HttpClientHandler
            {
                AllowAutoRedirect = true,
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            }, handlers);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 0.7));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.2));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.1));
            client.DefaultRequestHeaders.AcceptEncoding.Clear();
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip", 0.7));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate", 0.2));
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("*", 0.1));
            client.Timeout = 1.Minutes();
            client.BaseAddress = new Uri("http://mock.jinyinmao.com.cn/");
            return client;
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="T:System.Net.Http.HttpClient" />.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="handlers">The list of HTTP handler that delegates the processing of HTTP response messages to another handler.</param>
        /// <returns>A new instance of the <see cref="T:System.Net.Http.HttpClient" />.</returns>
        public static HttpClient Create(string serviceName, TraceEntry traceEntry, string userId, params DelegatingHandler[] handlers)
        {
            if (userId.IsNotNullOrEmpty())
            {
                traceEntry.UserId = userId;
            }

            return Create(serviceName, traceEntry, handlers);
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="T:System.Net.Http.HttpClient" />.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="request">The request.</param>
        /// <param name="handlers">The list of HTTP handler that delegates the processing of HTTP response messages to another handler.</param>
        /// <returns>A new instance of the <see cref="T:System.Net.Http.HttpClient" />.</returns>
        public static HttpClient Create(string serviceName, HttpRequestMessage request, params DelegatingHandler[] handlers)
        {
            return Create(serviceName, request, "", handlers);
        }

        /// <summary>
        ///     Creates a new instance of the <see cref="T:System.Net.Http.HttpClient" />.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="request">The request.</param>
        /// <param name="userId">The user identifier.</param>
        /// <param name="handlers">The list of HTTP handler that delegates the processing of HTTP response messages to another handler.</param>
        /// <returns>A new instance of the <see cref="T:System.Net.Http.HttpClient" />.</returns>
        public static HttpClient Create(string serviceName, HttpRequestMessage request, string userId, params DelegatingHandler[] handlers)
        {
            return Create(serviceName, request.GetTraceEntry(), userId, handlers);
        }
    }
}