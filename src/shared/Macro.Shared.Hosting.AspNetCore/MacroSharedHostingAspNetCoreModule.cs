using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Modularity;
using Volo.Abp.Swashbuckle;
using Volo.Abp.VirtualFileSystem;

namespace Macro.Shared.Hosting.AspNetCore;

[DependsOn(
    typeof(MacroSharedHostingModule),
    typeof(MacroSharedLocalizationModule),
    typeof(AbpAspNetCoreSerilogModule),
    typeof(AbpSwashbuckleModule)
)]
public class MacroSharedHostingAspNetCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<MacroSharedHostingAspNetCoreModule>("EShopOnAbp.Shared.Hosting.AspNetCore");
        });
    }
}