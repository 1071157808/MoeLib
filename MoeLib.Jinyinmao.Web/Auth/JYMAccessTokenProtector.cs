using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using Moe.Lib;

namespace MoeLib.Jinyinmao.Web.Auth
{
    /// <summary>
    ///     JYMAccessTokenProtector.
    /// </summary>
    internal class JYMAccessTokenProtector
    {
        private const string Anonymous = "Anonymous";

        private const string Unspecified = "Unspecified";

        /// <summary>
        ///     The RSA crypto service provider
        /// </summary>
        private readonly RSACryptoServiceProvider rsaCryptoServiceProvider;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JYMAccessTokenProtector" /> class.
        /// </summary>
        /// <param name="key">The cryptographic key.</param>
        internal JYMAccessTokenProtector(string key)
        {
            this.rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            this.rsaCryptoServiceProvider.FromXmlString(key);
        }

        internal string Protect(ClaimsIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            string name = identity.Name ?? Anonymous;
            Claim claim = identity.FindFirst(ClaimTypes.Expiration);
            long timestamp = claim?.Value?.AsLong() ?? DateTime.UtcNow.UnixTimestamp();
            string scheme = identity.AuthenticationType ?? Unspecified;
            string payload = $"{name},{timestamp},{scheme}";

            return this.rsaCryptoServiceProvider.Encrypt(payload.GetBytesOfASCII(), false).ToBase64String();
        }

        internal ClaimsIdentity Unprotect(string protectedData)
        {
            if (protectedData == null)
            {
                throw new ArgumentNullException(nameof(protectedData));
            }

            List<Claim> claims = new List<Claim>();

            try
            {
                byte[] unprotectedData = this.rsaCryptoServiceProvider.Decrypt(protectedData.ToBase64Bytes(), false);
                string identityData = unprotectedData.ASCII();
                string[] identityDatas = identityData.Split(',');
                long timestamp = identityDatas[1]?.AsLong() ?? 0L;
                if (timestamp < DateTime.UtcNow.UnixTimestamp())
                {
                    claims.Add(new Claim(ClaimTypes.Expired, "True"));
                }
                else
                {
                    claims.Add(new Claim(ClaimTypes.Name, identityDatas[0] ?? Anonymous));
                    claims.Add(new Claim(ClaimTypes.Role, "User"));
                    return new ClaimsIdentity(claims, identityDatas[2] ?? Unspecified);
                }
            }
            catch (Exception e)
            {
                claims.Add(new Claim(ClaimTypes.AuthorizationDecision, "Error:" + e.Message));
            }

            return new ClaimsIdentity(claims);
        }
    }
}