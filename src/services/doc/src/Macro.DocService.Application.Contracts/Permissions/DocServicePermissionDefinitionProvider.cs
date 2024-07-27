using DocService.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace DocService.Permissions;

public class DocServicePermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(DocServicePermissions.GroupName);

        var booksPermission = myGroup.AddPermission(DocServicePermissions.Books.Default, L("Permission:Books"));
        booksPermission.AddChild(DocServicePermissions.Books.Create, L("Permission:Books.Create"));
        booksPermission.AddChild(DocServicePermissions.Books.Edit, L("Permission:Books.Edit"));
        booksPermission.AddChild(DocServicePermissions.Books.Delete, L("Permission:Books.Delete"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(DocServicePermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<DocServiceResource>(name);
    }
}
