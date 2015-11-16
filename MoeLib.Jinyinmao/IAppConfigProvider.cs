using System;

namespace MoeLib.Jinyinmao
{
    public interface IAppConfigProvider
    {
        Guid GetDeploymentIdConfig();

        string GetPrivateKeyConfig();

        string GetRoleConfig();

        string GetRoleInstanceConfig();
    }
}