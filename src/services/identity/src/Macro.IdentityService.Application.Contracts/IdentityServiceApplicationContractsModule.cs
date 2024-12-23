using Volo.Abp.Identity;
using Volo.Abp.Modularity;

namespace Macro.IdentityService;

[DependsOn(
    typeof(IdentityServiceDomainSharedModule),
    typeof(AbpIdentityApplicationContractsModule)
)]
public class IdentityServiceApplicationContractsModule : AbpModule
{
}