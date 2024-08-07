using Volo.Abp.Application;
using Volo.Abp.Authorization;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Macro.SaaS;

[DependsOn(
    typeof(SaasDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
)]
[DependsOn(typeof(AbpTenantManagementApplicationContractsModule))]
public class SaasApplicationContractsModule : AbpModule
{
}