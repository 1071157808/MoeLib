using System.Web.Http;
using Moe.Lib.Web;

namespace MoeLibWebLab
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.UseJinyinmaoLogger();

            // Web API routes
            config.MapHttpAttributeRoutes();
        }
    }
}