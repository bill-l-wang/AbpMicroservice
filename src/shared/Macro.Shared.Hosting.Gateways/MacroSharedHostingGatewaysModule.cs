using Macro.Shared.Hosting.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Modularity;

namespace Macro.Shared.Hosting.Gateways
{
    [DependsOn(
        typeof(MacroSharedHostingAspNetCoreModule)
    )]
    public class MacroSharedHostingGatewaysModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            var configuration = context.Services.GetConfiguration();

            context.Services.AddHttpForwarderWithServiceDiscovery();
            
            context.Services.AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"))
                .AddServiceDiscoveryDestinationResolver();
        }
    }
}