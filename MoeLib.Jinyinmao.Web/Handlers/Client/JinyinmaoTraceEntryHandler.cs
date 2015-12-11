using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moe.Lib;
using Moe.Lib.Jinyinmao;
using MoeLib.Diagnostics;
using MoeLib.Jinyinmao.Web.Diagnostics;

namespace MoeLib.Jinyinmao.Web.Handlers.Client
{
    /// <summary>
    ///     JinyinmaoTraceEntryHandler.
    /// </summary>
    public class JinyinmaoTraceEntryHandler : DelegatingHandler
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoTraceEntryHandler" /> class.
        /// </summary>
        /// <param name="traceEntry">The trace entry.</param>
        public JinyinmaoTraceEntryHandler(TraceEntry traceEntry)
        {
            this.TraceEntry = traceEntry;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoTraceEntryHandler" /> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public JinyinmaoTraceEntryHandler(HttpRequestMessage request)
        {
            this.TraceEntry = request.GetTraceEntry();
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoTraceEntryHandler" /> class.
        /// </summary>
        /// <param name="traceEntry">The trace entry.</param>
        /// <param name="userId">The user identifier.</param>
        public JinyinmaoTraceEntryHandler(TraceEntry traceEntry, string userId)
        {
            this.TraceEntry = traceEntry;
            this.TraceEntry.UserId = userId;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoTraceEntryHandler" /> class.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="userId">The user identifier.</param>
        public JinyinmaoTraceEntryHandler(HttpRequestMessage request, string userId)
        {
            this.TraceEntry = request.GetTraceEntry();
            this.TraceEntry.UserId = userId;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="JinyinmaoTraceEntryHandler" /> class.
        /// </summary>
        public JinyinmaoTraceEntryHandler()
        {
            this.TraceEntry = null;
        }

        private TraceEntry TraceEntry { get; set; }

        /// <summary>
        ///     Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <returns>
        ///     Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.
        /// </returns>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (this.TraceEntry == null)
            {
                request.Headers.TryAddWithoutValidation("X-JYM-CID", App.Host.RoleInstance);
                request.Headers.TryAddWithoutValidation("X-JYM-RID", Guid.NewGuid().ToGuidString());
                request.Headers.TryAddWithoutValidation("X-JYM-SID", Guid.NewGuid().ToGuidString());
            }
            else
            {
                request.Headers.TryAddWithoutValidation("X-JYM-CID", this.TraceEntry.ClientId + "," + App.Host.RoleInstance);
                request.Headers.TryAddWithoutValidation("X-JYM-RID", this.TraceEntry.RequestId ?? Guid.NewGuid().ToGuidString());
                request.Headers.TryAddWithoutValidation("X-JYM-SID", this.TraceEntry.SessionId ?? Guid.NewGuid().ToGuidString());
                if (this.TraceEntry.SourceIP.IsNullOrEmpty())
                {
                    request.Headers.TryAddWithoutValidation("X-JYM-IP", this.TraceEntry.SourceIP);
                }
                if (this.TraceEntry.SourceUserAgent.IsNullOrEmpty())
                {
                    request.Headers.TryAddWithoutValidation("X-JYM-UA", this.TraceEntry.SourceUserAgent);
                }
                if (this.TraceEntry.UserId.IsNullOrEmpty())
                {
                    request.Headers.TryAddWithoutValidation("X-JYM-UID", this.TraceEntry.UserId);
                }
            }

            return base.SendAsync(request, cancellationToken);
        }
    }
}