using System.Web;
using System.Web.Http;
using Moe.Lib.Jinyinmao;
using MoeLib.Jinyinmao.Azure;

namespace MoeLibWebLab
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            App.Initialize().ConfigWithAzure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}