using Volo.Abp.Reflection;

namespace Macro.AdministrationService.Permissions;

public class AdministrationServicePermissions
{
    public const string GroupName = "Administration";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(AdministrationServicePermissions));
    }
}