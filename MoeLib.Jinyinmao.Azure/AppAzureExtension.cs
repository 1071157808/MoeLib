using Moe.Lib.Jinyinmao;

namespace MoeLib.Jinyinmao.Azure
{
    public static class AppAzureExtension
    {
        public static App ConfigWithAzure(this App app)
        {
            return app.Config(new AzureAppConfigProvider());
        }
    }
}