using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Macro.Saas;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SaasDomainSharedModule)
)]
[DependsOn(typeof(AbpTenantManagementDomainModule))]
public class SaasDomainModule : AbpModule
{
}