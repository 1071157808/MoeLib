using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace Moe.Lib.TransientFaultHandling
{
    /// <summary>
    ///     HttpTransientErrorDetectionStrategy.
    /// </summary>
    public class HttpRequestTransientErrorDetectionStrategy : ITransientErrorDetectionStrategy
    {
        private readonly IList<HttpStatusCode> statusCodes =
            new List<HttpStatusCode>
            {
                HttpStatusCode.RequestTimeout,
                HttpStatusCode.ServiceUnavailable,
                HttpStatusCode.GatewayTimeout
            };

        #region ITransientErrorDetectionStrategy Members

        /// <summary>
        ///     Determines whether the specified exception represents a transient failure that can be compensated by a retry.
        /// </summary>
        /// <param name="ex">The exception object to be verified.</param>
        /// <returns>
        ///     true if the specified exception is considered as transient; otherwise, false.
        /// </returns>
        public bool IsTransient(Exception ex)
        {
            WebException we = ex as WebException;
            HttpWebResponse response = we?.Response as HttpWebResponse;
            return response != null && this.statusCodes.Contains(response.StatusCode);
        }

        #endregion ITransientErrorDetectionStrategy Members
    }
}