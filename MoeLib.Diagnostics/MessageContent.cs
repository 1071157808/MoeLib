using System.Collections.Generic;

namespace MoeLib.Diagnostics
{
    /// <summary>
    ///     MessageContent.
    /// </summary>
    public class MessageContent
    {
        /// <summary>
        ///     Gets or sets the client identifier.
        /// </summary>
        /// <value>The client identifier.</value>
        public string ClientId { get; set; }

        /// <summary>
        ///     Gets or sets the device identifier.
        /// </summary>
        /// <value>The device identifier.</value>
        public string DeviceId { get; set; }

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
        ///     Gets or sets the request identifier.
        /// </summary>
        /// <value>The request identifier.</value>
        public string RequestId { get; set; }

        /// <summary>
        ///     Gets or sets the session identifier.
        /// </summary>
        /// <value>The session identifier.</value>
        public string SessionId { get; set; }

        /// <summary>
        ///     Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public string Tag { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; set; }
    }
}