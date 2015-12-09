using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using Moe.Lib;
using MoeLib.Diagnostics;
using MoeLib.Jinyinmao.Web.Diagnostics;
using MoeLib.Jinyinmao.Web.Handlers;

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

            HttpClient client = HttpClientFactory.Create(new HttpClientHandler(), handlers);
            client.Timeout = 1.Minutes();
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
            IList<DelegatingHandler> delegatingHandlers = new List<DelegatingHandler>();
            delegatingHandlers.Add(new JinyinmaoServicePermissionHandler(serviceName));
            delegatingHandlers.Add(new JinyinmaoTraceEntryHandler(traceEntry, userId));
            delegatingHandlers.Add(new JinyinmaoHttpStatusHandler());
            delegatingHandlers.Add(new JinyinmaoLogHandler("HTTP Client Request", "HTTP Client Response"));
            delegatingHandlers.Add(new JinyinmaoRetryHandler());

            HttpClient client = HttpClientFactory.Create(new HttpClientHandler(), handlers);
            client.Timeout = 1.Minutes();
            return client;
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
            IList<DelegatingHandler> delegatingHandlers = new List<DelegatingHandler>();
            delegatingHandlers.Add(new JinyinmaoServicePermissionHandler(serviceName));
            delegatingHandlers.Add(new JinyinmaoTraceEntryHandler(request));
            delegatingHandlers.Add(new JinyinmaoHttpStatusHandler());
            delegatingHandlers.Add(new JinyinmaoLogHandler("HTTP Client Request", "HTTP Client Response"));
            delegatingHandlers.Add(new JinyinmaoRetryHandler());

            HttpClient client = HttpClientFactory.Create(new HttpClientHandler(), delegatingHandlers.ToArray());
            client.Timeout = 1.Minutes();
            return client;
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
            IList<DelegatingHandler> delegatingHandlers = new List<DelegatingHandler>();
            delegatingHandlers.Add(new JinyinmaoServicePermissionHandler(serviceName));
            delegatingHandlers.Add(new JinyinmaoTraceEntryHandler(request, userId));
            delegatingHandlers.Add(new JinyinmaoHttpStatusHandler());
            delegatingHandlers.Add(new JinyinmaoLogHandler("HTTP Client Request", "HTTP Client Response"));
            delegatingHandlers.Add(new JinyinmaoRetryHandler());

            HttpClient client = HttpClientFactory.Create(new HttpClientHandler(), handlers);
            client.Timeout = 1.Minutes();
            return client;
        }
    }
}