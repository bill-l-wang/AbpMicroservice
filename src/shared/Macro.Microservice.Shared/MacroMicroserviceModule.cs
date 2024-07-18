using Macro.Administration.EntityFrameworkCore;
using Macro.Hosting.Shared;
using Volo.Abp.Modularity;

namespace Macro.Microservice.Shared;

[DependsOn(
    typeof(MacroHostingModule),
    typeof(AdministrationEntityFrameworkCoreModule)
)]
public class MacroMicroserviceModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
    }
}