using Macro.Saas.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Macro.Saas.Permissions;

public class SaasPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(SaasPermissions.GroupName, L("Permission:SaaS"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<SaasResource>(name);
    }
}