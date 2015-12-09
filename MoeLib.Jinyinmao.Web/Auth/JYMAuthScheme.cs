namespace MoeLib.Jinyinmao.Web.Auth
{
    /// <summary>
    ///     JYMAuthScheme.
    /// </summary>
    public static class JYMAuthScheme
    {
        /// <summary>
        ///     Basic
        /// </summary>
        public static readonly string Basic = "Basic";

        /// <summary>
        ///     Bearer
        /// </summary>
        public static readonly string Bearer = "Bearer";

        /// <summary>
        /// The jym internal authentication
        /// </summary>
        public static readonly string JYMInternalAuth = "JIAUTH";

        /// <summary>
        ///     JYMQuick
        /// </summary>
        public static readonly string JYMQuick = "JYMQuick";

        /// <summary>
        ///     JYMWeChat
        /// </summary>
        public static readonly string JYMWeChat = "JYMWeChat";
    }
}