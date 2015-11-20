using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

namespace MoeLib.Jinyinmao.Web.Handlers
{
    public class JinyinmaoExceptionHandler : ExceptionHandler
    {
        /// <summary>
        ///     When overridden in a derived class, handles the exception synchronously.
        /// </summary>
        /// <param name="context">The exception handler context.</param>
        public override void Handle(ExceptionHandlerContext context)
        {
            context.Result = new ErrorResult
            {
                Exception = context.Exception,
                Request = context.ExceptionContext.Request
            };
        }

        /// <summary>
        ///     Determines whether the exception should be handled.
        /// </summary>
        /// <returns>
        ///     true if the exception should be handled; otherwise, false.
        /// </returns>
        /// <param name="context">The exception handler context.</param>
        public override bool ShouldHandle(ExceptionHandlerContext context)
        {
            return true;
        }

        #region Nested type: ErrorResult

        private sealed class ErrorResult : IHttpActionResult
        {
            internal Exception Exception { private get; set; }
            internal HttpRequestMessage Request { private get; set; }

            #region IHttpActionResult Members

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                HttpResponseMessage response;
                if (this.Exception is NotImplementedException)
                {
                    response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
                }
                else
                {
                    response = this.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, this.Exception);
                }
                return Task.FromResult(response);
            }

            #endregion IHttpActionResult Members
        }

        #endregion Nested type: ErrorResult
    }
}