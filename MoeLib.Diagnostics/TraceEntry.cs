namespace MoeLib.Diagnostics
{
    /// <summary>
    ///     TraceEntry.
    /// </summary>
    public class TraceEntry
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
        ///     Gets or sets the source ip.
        /// </summary>
        /// <value>The source ip.</value>
        public string SourceIP { get; set; }

        /// <summary>
        ///     Gets or sets the source user agent.
        /// </summary>
        /// <value>The source user agent.</value>
        public string SourceUserAgent { get; set; }

        /// <summary>
        ///     Gets or sets the user identifier.
        /// </summary>
        /// <value>The user identifier.</value>
        public string UserId { get; set; }
    }
}