﻿using Macro.AdministrationService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Macro.AdministrationService.Permissions;

public class AdministrationServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(AdministrationServicePermissions.GroupName, L("Permission:Administration"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<AdministrationServiceResource>(name);
    }
}