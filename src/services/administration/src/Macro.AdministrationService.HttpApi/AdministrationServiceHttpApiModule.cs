using Localization.Resources.AbpUi;
using Macro.AdministrationService.Localization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;

namespace Macro.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
)]
public class AdministrationServiceHttpApiModule : AbpModule
{
    
}