using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Moe.Lib;
using Moe.Lib.Jinyinmao;

namespace MoeLib.Jinyinmao.Configs.GovernmentHttpClient
{
    /// <summary>
    ///     ApplicationIdentityMessageHandler.
    /// </summary>
    public class ApplicationIdentityMessageHandler : DelegatingHandler
    {
        private static readonly RSACryptoServiceProvider cryptoServiceProvider = new RSACryptoServiceProvider(2048);

        /// <summary>
        ///     Initializes a new instance of the <see cref="ApplicationIdentityMessageHandler" /> class.
        /// </summary>
        public ApplicationIdentityMessageHandler()
        {
            cryptoServiceProvider.FromXmlString(App.Host.AppKeys);
        }

        /// <summary>
        ///     Sends an HTTP request to the inner handler to send to the server as an asynchronous operation.
        /// </summary>
        /// <returns>
        ///     Returns <see cref="T:System.Threading.Tasks.Task`1" />. The task object representing the asynchronous operation.
        /// </returns>
        /// <param name="request">The HTTP request message to send to the server.</param>
        /// <param name="cancellationToken">A cancellation token to cancel operation.</param>
        /// <exception cref="T:System.ArgumentNullException">The <paramref name="request" /> was null.</exception>
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            string sign = cryptoServiceProvider.SignData(App.Host.Role.ToBase64Bytes(), new SHA1CryptoServiceProvider()).ToBase64String();
            string ticket = $"{App.Host.Role},{sign}";
            request.Headers.Authorization = new AuthenticationHeaderValue("JIAUTH", ticket);
            request.Headers.TryAddWithoutValidation("X-JYM-CID", App.Host.RoleInstance);
            request.Headers.TryAddWithoutValidation("X-JYM-RID", Guid.NewGuid().ToGuidString());
            request.Headers.TryAddWithoutValidation("X-JYM-SID", Guid.NewGuid().ToGuidString());
            request.Headers.Accept.Clear();
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json", 1.0));
            return base.SendAsync(request, cancellationToken);
        }
    }
}