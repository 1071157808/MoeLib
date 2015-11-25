// ***********************************************************************
// Project          : MoeLib
// File             : MessageContent.cs
// Created          : 2015-11-20  5:55 PM
//
// Last Modified By : Siqi Lu(lu.siqi@outlook.com)
// Last Modified On : 2015-11-25  2:50 PM
// ***********************************************************************
// <copyright file="MessageContent.cs" company="Shanghai Yuyi Mdt InfoTech Ltd.">
//     Copyright ©  2012-2015 Shanghai Yuyi Mdt InfoTech Ltd. All rights reserved.
// </copyright>
// ***********************************************************************

using System.Collections.Generic;

namespace MoeLib.Diagnostics
{
    /// <summary>
    ///     MessageContent.
    /// </summary>
    public class MessageContent : TraceEntry
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageContent" /> class.
        /// </summary>
        public MessageContent()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="MessageContent" /> class.
        /// </summary>
        /// <param name="traceEntry">The trace entry.</param>
        public MessageContent(TraceEntry traceEntry)
        {
            if (traceEntry != null)
            {
                this.ClientId = traceEntry.ClientId;
                this.DeviceId = traceEntry.DeviceId;
                this.RequestId = traceEntry.RequestId;
                this.SessionId = traceEntry.SessionId;
                this.SourceIP = traceEntry.SourceIP;
                this.SourceUserAgent = traceEntry.SourceUserAgent;
                this.UserId = traceEntry.UserId;
            }
        }

        /// <summary>
        ///     Gets or sets the error code.
        /// </summary>
        /// <value>The error code.</value>
        public ulong ErrorCode { get; set; }

        /// <summary>
        ///     Gets or sets the error code MSG.
        /// </summary>
        /// <value>The error code MSG.</value>
        public string ErrorCodeMsg { get; set; }

        /// <summary>
        ///     Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }

        /// <summary>
        ///     Gets or sets the payload.
        /// </summary>
        /// <value>The payload.</value>
        public Dictionary<string, object> Payload { get; set; }

        /// <summary>
        ///     Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public string Tag { get; set; }
    }
}