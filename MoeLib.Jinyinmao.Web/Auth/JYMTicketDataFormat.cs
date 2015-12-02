using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Microsoft.Owin.Security.DataProtection;

namespace MoeLib.Jinyinmao.Web.Auth
{
    /// <summary>
    ///     JYMTicketDataFormat.
    /// </summary>
    public class JYMTicketDataFormat : SecureDataFormat<AuthenticationTicket>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="JYMTicketDataFormat" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        /// <param name="protector">The protector.</param>
        public JYMTicketDataFormat(IDataSerializer<AuthenticationTicket> serializer, IDataProtector protector)
            : base(serializer, protector, TextEncodings.Base64)
        {
        }
    }
}