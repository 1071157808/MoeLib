using System;

namespace MoeLib.Diagnostics
{
    public class LogEntry
    {
        public string DeploymentId { get; set; }
        public ulong ErrorCode { get; set; }
        public string ErrorCodeMsg { get; set; }
        public string EventId { get; set; }
        public string Function { get; set; }
        public int Level { get; set; }
        public MessageContent Message { get; set; }
        public DateTime PreciseTimestamp { get; set; }
        public string Role { get; set; }
        public string RoleInstance { get; set; }
    }
}