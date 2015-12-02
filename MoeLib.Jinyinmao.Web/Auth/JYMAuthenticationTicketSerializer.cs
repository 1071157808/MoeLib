using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Serializer;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Security.Claims;

namespace Jinyinmao.AuthManager.Api.Auth
{
    /// <summary>
    ///     Class JYMAuthenticationTicketSerializer.
    /// </summary>
    internal class JYMAuthenticationTicketSerializer : IDataSerializer<AuthenticationTicket>
    {
        #region IDataSerializer<AuthenticationTicket> Members

        /// <summary>
        ///     Deserializes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>AuthenticationTicket.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public AuthenticationTicket Deserialize(byte[] data)
        {
            // TODO: Deserialize

            throw new NotImplementedException();
        }

        public byte[] Serialize(AuthenticationTicket model)
        {
            if (model?.Identity == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            MemoryStream memory = new MemoryStream();
            try
            {
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(new StreamWriter(memory)))
                {
                    jsonTextWriter.Formatting = Formatting.None;
                    jsonTextWriter.WriteStartObject();
                    jsonTextWriter.WritePropertyName("identity");

                    jsonTextWriter.WriteStartObject();
                    jsonTextWriter.WritePropertyName("claims");

                    jsonTextWriter.WriteStartArray();

                    foreach (Claim claim in model.Identity.Claims)
                    {
                        jsonTextWriter.WriteStartObject();
                        jsonTextWriter.WritePropertyName("issuer");
                        jsonTextWriter.WriteValue(claim.Issuer);
                        jsonTextWriter.WritePropertyName("type");
                        jsonTextWriter.WriteValue(claim.Type);
                        jsonTextWriter.WritePropertyName("value");
                        jsonTextWriter.WriteValue(claim.Value);
                        jsonTextWriter.WritePropertyName("valueType");
                        jsonTextWriter.WriteValue(claim.ValueType);
                        jsonTextWriter.WriteEndObject();
                    }

                    jsonTextWriter.WriteEndArray();

                    jsonTextWriter.WritePropertyName("isAuthenticated");
                    jsonTextWriter.WriteValue(model.Identity.IsAuthenticated);
                    jsonTextWriter.WritePropertyName("name");
                    jsonTextWriter.WriteValue(model.Identity.Name);

                    jsonTextWriter.WriteEndObject();

                    jsonTextWriter.WritePropertyName("issued");
                    if (model.Properties.IssuedUtc.HasValue)
                    {
                        jsonTextWriter.WriteValue(model.Properties.IssuedUtc);
                    }
                    else
                    {
                        jsonTextWriter.WriteValue(new DateTimeOffset(DateTime.UtcNow));
                    }
                    jsonTextWriter.WritePropertyName("expires");
                    if (model.Properties.ExpiresUtc.HasValue)
                    {
                        jsonTextWriter.WriteValue(model.Properties.ExpiresUtc);
                    }
                    else
                    {
                        jsonTextWriter.WriteValue(new DateTimeOffset(DateTime.UtcNow.AddMinutes(5)));
                    }

                    jsonTextWriter.WriteEndObject();

                    jsonTextWriter.Flush();
                }

                return memory.ToArray();
            }
            finally
            {
                memory.Dispose();
            }
        }

        #endregion IDataSerializer<AuthenticationTicket> Members
    }
}