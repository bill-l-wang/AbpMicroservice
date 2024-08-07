using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.TenantManagement;

namespace Macro.SaaS;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(SaasDomainSharedModule)
)]
[DependsOn(typeof(AbpTenantManagementDomainModule))]
public class SaasDomainModule : AbpModule
{
}