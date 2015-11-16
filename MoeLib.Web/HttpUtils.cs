using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using ReflectionMagic;

namespace Moe.Lib.Web
{
    /// <summary>
    ///     HttpUtils.
    /// </summary>
    public static class HttpUtils
    {
        /// <summary>
        ///     The HTTP context base key
        /// </summary>
        private const string HTTP_CONTEXT_BASE_KEY = "MS_HttpContext";

        /// <summary>
        ///     Copies the request headers for batch request.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        public static void CopyRequestHeaders(IEnumerable<KeyValuePair<string, IEnumerable<string>>> source, HttpRequestHeaders destination)
        {
            foreach (KeyValuePair<string, IEnumerable<string>> header in source)
            {
                switch (header.Key)
                {
                    case "User-Agent":
                        destination.Add(header.Key, "nyanya/1.0");
                        break;

                    case "Via":
                        break;

                    default:
                        destination.Add(header.Key, string.Join(",", header.Value));
                        break;
                }
            }
        }

        /// <summary>
        ///     Dumps the specified request include headers.
        /// </summary>
        /// <param name="httpRequest">The HTTP request.</param>
        /// <param name="includeHeaders">if set to <c>true</c> [include headers].</param>
        /// <returns>System.String.</returns>
        public static string Dump(this HttpRequest httpRequest, bool includeHeaders = true)
        {
            MemoryStream memoryStream = new MemoryStream();

            try
            {
                TextWriter writer = new StreamWriter(memoryStream);

                writer.Write(httpRequest.HttpMethod);
                writer.Write(httpRequest.Url.AbsoluteUri);

                // headers

                if (includeHeaders)
                {
                    if (httpRequest.AsDynamic()._wr != null)
                    {
                        // real request -- add protocol
                        writer.Write(" " + httpRequest.AsDynamic()._wr.GetHttpVersion() + "\r\n");

                        // headers
                        writer.Write(httpRequest.AsDynamic().CombineAllHeaders(true));
                    }
                    else
                    {
                        // manufactured request
                        writer.Write("\r\n");
                    }
                }

                writer.Write("\r\n");
                writer.Flush();

                // entity body

                dynamic httpInputStream = httpRequest.AsDynamic().InputStream;
                httpInputStream.WriteTo(memoryStream);

                StreamReader reader = new StreamReader(memoryStream);
                return reader.ReadToEnd();
            }
            finally
            {
                memoryStream.Close();
            }
        }

        /// <summary>
        ///     Dumps the specified request include headers.
        /// </summary>
        /// <param name="httpRequest">The HTTP request.</param>
        /// <param name="includeHeaders">if set to <c>true</c> [include headers].</param>
        /// <returns>System.String.</returns>
        public static string Dump(this HttpRequestMessage httpRequest, bool includeHeaders = true)
        {
            MemoryStream memoryStream = new MemoryStream();

            try
            {
                TextWriter writer = new StreamWriter(memoryStream);

                writer.Write(httpRequest.Method + "\r\n");
                writer.Write(httpRequest.RequestUri.AbsoluteUri + "\r\n");
                writer.Write(httpRequest.Version + "\r\n");

                // headers

                if (includeHeaders)
                {
                    foreach (KeyValuePair<string, IEnumerable<string>> header in httpRequest.Headers)
                    {
                        writer.Write(header.Key + ": " + header.Value.Join(","));
                    }
                }

                writer.Write("\r\n");
                writer.Flush();

                // entity body

                Task<string> contentTask = httpRequest.Content.ReadAsStringAsync();
                contentTask.Wait();
                writer.Write(contentTask.Result);

                StreamReader reader = new StreamReader(memoryStream);
                return reader.ReadToEnd();
            }
            finally
            {
                memoryStream.Close();
            }
        }

        /// <summary>
        ///     Gets the HTTP httpContext.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>HttpContext.</returns>
        public static HttpContext GetHttpContext(HttpRequestMessage request)
        {
            HttpContextBase contextBase = GetHttpContextBase(request);

            return contextBase == null ? null : ToHttpContext(contextBase);
        }

        /// <summary>
        ///     Gets the HTTP httpContext.
        /// </summary>
        /// <param name="contextBase">The httpContext base.</param>
        /// <returns>HttpContext.</returns>
        public static HttpContext GetHttpContext(HttpContextBase contextBase)
        {
            return contextBase.ApplicationInstance.Context;
        }

        /// <summary>
        ///     Gets the user agent.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.String.</returns>
        public static string GetUserAgent(HttpRequestMessage request)
        {
            return GetUserAgent(request.ToHttpContext());
        }

        /// <summary>
        ///     Gets the user agent.
        /// </summary>
        /// <param name="httpContext">The HTTP httpContext.</param>
        /// <returns>System.String.</returns>
        public static string GetUserAgent(HttpContext httpContext)
        {
            return httpContext == null ? "" : httpContext.Request.UserAgent;
        }

        /// <summary>
        ///     Gets the user host address.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>System.String.</returns>
        public static string GetUserHostAddress(HttpRequestMessage request)
        {
            return GetUserHostAddress(request.ToHttpContext());
        }

        /// <summary>
        ///     Gets the user host address.
        /// </summary>
        /// <param name="httpContext">The HTTP httpContext.</param>
        /// <returns>System.String.</returns>
        public static string GetUserHostAddress(HttpContext httpContext)
        {
            return httpContext == null ? "" : httpContext.Request.UserHostAddress;
        }

        /// <summary>
        ///     Determines whether the specified HTTP httpContext is from dev.
        /// </summary>
        /// <param name="httpContext">The HTTP httpContext.</param>
        /// <param name="ipStartWith">The ip start with.</param>
        /// <returns><c>true</c> if the specified HTTP httpContext is dev; otherwise, <c>false</c>.</returns>
        public static bool IsFrom(HttpContext httpContext, string ipStartWith)
        {
            string ip = GetUserHostAddress(httpContext);
            return !string.IsNullOrEmpty(ip) && ip.StartsWith(ipStartWith, StringComparison.Ordinal);
        }

        /// <summary>
        ///     Determines whether the specified HTTP httpContext is from dev.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="ipStartWith">The ip start with.</param>
        /// <returns><c>true</c> if the specified HTTP httpContext is dev; otherwise, <c>false</c>.</returns>
        public static bool IsFrom(HttpRequestMessage request, string ipStartWith)
        {
            return IsFrom(request.ToHttpContext(), ipStartWith);
        }

        /// <summary>
        ///     Determines whether the specified request is from ios.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if the specified request is ios; otherwise, <c>false</c>.</returns>
        public static bool IsFromIos(HttpRequestMessage request)
        {
            return IsFromIos(request.ToHttpContext());
        }

        /// <summary>
        ///     Determines whether the specified request is from ios.
        /// </summary>
        /// <param name="httpContext">The HTTP httpContext.</param>
        /// <returns><c>true</c> if the specified request is ios; otherwise, <c>false</c>.</returns>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static bool IsFromIos(HttpContext httpContext)
        {
            string userAgent = GetUserAgent(httpContext);
            return userAgent != null && (userAgent.ToUpperInvariant().Contains("IPHONE") || userAgent.ToUpperInvariant().Contains("IPAD") || userAgent.ToUpperInvariant().Contains("IPOD"));
        }

        /// <summary>
        ///     Determines whether the specified HTTP httpContext is from localhost.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if the specified HTTP httpContext is localhost; otherwise, <c>false</c>.</returns>
        public static bool IsFromLocalhost(HttpRequestMessage request)
        {
            return IsFromLocalhost(request.ToHttpContext());
        }

        /// <summary>
        ///     Determines whether the specified HTTP httpContext is from localhost.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns><c>true</c> if the specified HTTP httpContext is localhost; otherwise, <c>false</c>.</returns>
        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static bool IsFromLocalhost(HttpContext httpContext)
        {
            return httpContext.Request.IsLocal;
        }

        /// <summary>
        ///     Determines whether the specified request is from mobile device.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns><c>true</c> if the specified request is from mobile device; otherwise, <c>false</c>.</returns>
        public static bool IsFromMobileBrowser(HttpContext httpContext)
        {
            return httpContext != null && httpContext.Request.Browser.IsMobileDevice;
        }

        /// <summary>
        ///     Determines whether the specified request is from mobile device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if the specified request is from mobile device; otherwise, <c>false</c>.</returns>
        public static bool IsFromMobileBrowser(HttpRequestMessage request)
        {
            return IsFromMobileDevice(request.ToHttpContext());
        }

        /// <summary>
        ///     Determines whether the specified request is from mobile device.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns><c>true</c> if the specified request is from mobile device; otherwise, <c>false</c>.</returns>
        public static bool IsFromMobileDevice(HttpRequestMessage request)
        {
            return IsFromMobileDevice(request.ToHttpContext());
        }

        /// <summary>
        ///     Determines whether the specified request is from mobile device.
        /// </summary>
        /// <param name="httpContext">The HTTP context.</param>
        /// <returns><c>true</c> if the specified request is from mobile device; otherwise, <c>false</c>.</returns>
        public static bool IsFromMobileDevice(HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return false;
            }

            string userAgent = GetUserAgent(httpContext);
            if (userAgent.IsNullOrEmpty())
            {
                return false;
            }

            userAgent = userAgent.ToUpperInvariant();

            return userAgent.Contains("IPHONE") || userAgent.Contains("IOS") || userAgent.Contains("IPAD")
                   || userAgent.Contains("ANDROID") || httpContext.Request.Browser.IsMobileDevice;
        }

        /// <summary>
        ///     Redirects to.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="uri">The URI.</param>
        /// <returns>HttpResponseMessage.</returns>
        public static HttpResponseMessage RedirectTo(HttpRequestMessage request, string uri)
        {
            return RedirectTo(request, new Uri(uri));
        }

        /// <summary>
        ///     Gets the HTTP httpContext.
        /// </summary>
        /// <param name="httpContextBase">The HTTP context base.</param>
        /// <returns>HttpContext.</returns>
        public static HttpContext ToHttpContext(this HttpContextBase httpContextBase)
        {
            return httpContextBase.ApplicationInstance.Context;
        }

        /// <summary>
        ///     Gets the HTTP httpContext.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>HttpContext.</returns>
        public static HttpContext ToHttpContext(this HttpRequestMessage request)
        {
            return GetHttpContext(request);
        }

        /// <summary>
        ///     Gets the HTTP httpContext base.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>HttpContextBase.</returns>
        public static HttpContextBase ToHttpContextBase(HttpRequestMessage request)
        {
            return GetHttpContextBase(request);
        }

        /// <summary>
        ///     Gets the HTTP httpContext base.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>HttpContextBase.</returns>
        private static HttpContextBase GetHttpContextBase(HttpRequestMessage request)
        {
            if (request == null)
            {
                return null;
            }

            object value;

            if (!request.Properties.TryGetValue(HTTP_CONTEXT_BASE_KEY, out value))
            {
                return null;
            }

            return value as HttpContextBase;
        }

        /// <summary>
        ///     Redirects to.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="uri">The URI.</param>
        /// <returns>HttpResponseMessage.</returns>
        private static HttpResponseMessage RedirectTo(HttpRequestMessage request, Uri uri)
        {
            HttpResponseMessage response = request.CreateResponse(HttpStatusCode.Moved);
            response.Headers.Location = uri;
            return response;
        }
    }
}