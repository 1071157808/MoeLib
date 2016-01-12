using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
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
        private static readonly Dictionary<string, HttpClient> clients = new Dictionary<string, HttpClient>();

        /// <summary>
        ///     Creates a new instance of the <see cref="T:System.Net.Http.HttpClient" />.
        /// </summary>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="handlers">The list of HTTP handler that delegates the processing of HTTP response messages to another handler.</param>
        /// <returns>A new instance of the <see cref="T:System.Net.Http.HttpClient" />.</returns>
        public static HttpClient Create(string serviceName, TraceEntry traceEntry, params DelegatingHandler[] handlers)
        {
            HttpClient client;
            if (!clients.TryGetValue(serviceName, out client))
            {
                List<DelegatingHandler> delegatingHandlers = new List<DelegatingHandler>
                {
                    new JinyinmaoServicePermissionHandler(serviceName),
                    //new JinyinmaoTraceEntryHandler(traceEntry),
                    new JinyinmaoHttpStatusHandler(),
                    new JinyinmaoLogHandler("HTTP Client Request", "HTTP Client Response"),
                    new JinyinmaoRetryHandler()
                };
                delegatingHandlers.AddRange(handlers);

                client = HttpClientFactory.Create(new HttpClientHandler
                {
                    AllowAutoRedirect = true,
                    AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
                }, delegatingHandlers.ToArray());

                client.BaseAddress = new Uri("http://service.jinyinmao.com.cn/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 1.0));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml", 0.5));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.1));
                client.DefaultRequestHeaders.AcceptEncoding.Clear();
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip", 1.0));
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate", 0.5));
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("*", 0.1));
                client.DefaultRequestHeaders.Connection.Add("keep-alive");

                client.Timeout = 3.Minutes();

                clients.Add(serviceName, client);
            }

            client.WithTraceEntry(traceEntry);

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

        /// <summary>
        ///     Withes the trace entry.
        /// </summary>
        /// <param name="httpClient">The HTTP client.</param>
        /// <param name="traceEntry">The trace entry.</param>
        /// <returns>HttpClient.</returns>
        public static HttpClient WithTraceEntry(this HttpClient httpClient, TraceEntry traceEntry = null)
        {
            if (traceEntry == null)
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-JYM-CID", App.Host.RoleInstance);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-JYM-RID", Guid.NewGuid().ToGuidString());
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-JYM-SID", Guid.NewGuid().ToGuidString());
            }
            else
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-JYM-CID", traceEntry.ClientId + "," + App.Host.RoleInstance);
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-JYM-RID", traceEntry.RequestId ?? Guid.NewGuid().ToGuidString());
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-JYM-SID", traceEntry.SessionId ?? Guid.NewGuid().ToGuidString());
                if (traceEntry.SourceIP.IsNullOrEmpty())
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-JYM-IP", traceEntry.SourceIP);
                }
                if (traceEntry.SourceUserAgent.IsNullOrEmpty())
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-JYM-UA", traceEntry.SourceUserAgent);
                }
                if (traceEntry.UserId.IsNullOrEmpty())
                {
                    httpClient.DefaultRequestHeaders.TryAddWithoutValidation("X-JYM-UID", traceEntry.UserId);
                }
            }

            return httpClient;
        }
    }
}