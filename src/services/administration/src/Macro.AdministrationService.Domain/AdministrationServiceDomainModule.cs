using Volo.Abp.AuditLogging;
using Volo.Abp.Domain;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.PermissionManagement.Identity;
using Volo.Abp.SettingManagement;

namespace Macro.AdministrationService;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(AdministrationServiceDomainSharedModule),
    typeof(AbpPermissionManagementDomainIdentityModule),
    typeof(AbpPermissionManagementDomainModule),
    typeof(AbpSettingManagementDomainModule),
    typeof(AbpAuditLoggingDomainModule),
    typeof(AbpFeatureManagementDomainModule)
)]
public class AdministrationServiceDomainModule : AbpModule
{
}