using Macro.Administration;
using Macro.AdministrationService;
using Macro.AdministrationService.EntityFrameworkCore;
using Macro.IdentityService;
using Macro.IdentityService.EntityFrameworkCore;
using Macro.Saas;
using Macro.SaaS;
using Macro.Saas.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Macro.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasEntityFrameworkCoreModule),
    typeof(SaasApplicationContractsModule)
)]
public class MacroDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        //Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}