using System;

namespace MoeLib.Jinyinmao
{
    public class Host
    {
        internal Host()
        {
        }

        public Guid DeploymentId { get; set; }

        public string PrivateKey { get; set; }

        public string Role { get; set; }

        public string RoleInstance { get; set; }
    }
}