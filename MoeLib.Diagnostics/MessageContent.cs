using System.Collections.Generic;

namespace MoeLib.Diagnostics
{
    public class MessageContent
    {
        public string ClientId { get; set; }
        public string DeviceId { get; set; }
        public ulong ErrorCode { get; set; }
        public string ErrorCodeMsg { get; set; }
        public string Message { get; set; }
        public Dictionary<string, object> Payload { get; set; }
        public string RequestId { get; set; }
        public string SessionId { get; set; }
        public string Tag { get; set; }
        public string UserId { get; set; }
    }
}