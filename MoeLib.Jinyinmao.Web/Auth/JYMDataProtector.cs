using System.Security.Cryptography;
using Microsoft.Owin.Security.DataProtection;

namespace Jinyinmao.AuthManager.Api.Auth
{
    /// <summary>
    ///     JYMDataProtector.
    /// </summary>
    public class JYMDataProtector : IDataProtector
    {
        /// <summary>
        ///     The RSA crypto service provider
        /// </summary>
        private readonly RSACryptoServiceProvider rsaCryptoServiceProvider;

        /// <summary>
        ///     Initializes a new instance of the <see cref="JYMDataProtector" /> class.
        /// </summary>
        /// <param name="key">The cryptographic key.</param>
        public JYMDataProtector(string key)
        {
            this.rsaCryptoServiceProvider = new RSACryptoServiceProvider();
            this.rsaCryptoServiceProvider.FromXmlString(key);
        }

        #region IDataProtector Members

        /// <summary>
        ///     Called to protect user data.
        /// </summary>
        /// <param name="userData">The original data that must be protected</param>
        /// <returns>
        ///     A different byte array that may be unprotected or altered only by software that has access to
        ///     the an identical IDataProtection service.
        /// </returns>
        public byte[] Protect(byte[] userData)
        {
            return this.rsaCryptoServiceProvider.EncryptValue(userData);
        }

        /// <summary>
        ///     Called to unprotect user data
        /// </summary>
        /// <param name="protectedData">The byte array returned by a call to Protect on an identical IDataProtection service.</param>
        /// <returns>The byte array identical to the original userData passed to Protect.</returns>
        public byte[] Unprotect(byte[] protectedData)
        {
            return this.rsaCryptoServiceProvider.DecryptValue(protectedData);
        }

        #endregion IDataProtector Members
    }
}