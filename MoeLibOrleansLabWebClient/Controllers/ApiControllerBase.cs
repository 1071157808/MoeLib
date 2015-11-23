using System.Web;
using MoeLib.Jinyinmao.Web;
using Orleans;
using Orleans.Runtime.Configuration;

namespace MoeLibOrleansLabWebClient.Controllers
{
    public abstract class ApiControllerBase : JinyinmaoApiControllerBase
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ApiControllerBase" /> class.
        /// </summary>
        protected ApiControllerBase()
        {
            if (GrainClient.IsInitialized)
            {
                return;
            }

            string configFilePath = HttpContext.Current.Server.MapPath(@"~/ClientConfiguration.xml");
            ClientConfiguration clientConfiguration = ClientConfiguration.LoadFromFile(configFilePath);
            GrainClient.Initialize(clientConfiguration);
        }
    }
}