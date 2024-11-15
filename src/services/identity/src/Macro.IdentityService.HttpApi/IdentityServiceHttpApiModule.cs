using Localization.Resources.AbpUi;
using Macro.IdentityService.Localization;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;

namespace Macro.IdentityService;

[DependsOn(
    typeof(IdentityServiceApplicationContractsModule),
    typeof(AbpIdentityHttpApiModule)
)]
public class IdentityServiceHttpApiModule : AbpModule
{
    
}