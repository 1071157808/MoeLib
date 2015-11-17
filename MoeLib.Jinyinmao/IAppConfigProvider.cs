using System;

namespace MoeLib.Jinyinmao
{
    public interface IAppConfigProvider
    {
        string GetAppKeysConfig();

        Guid GetDeploymentIdConfig();

        string GetRoleConfig();

        string GetRoleInstanceConfig();
    }
}