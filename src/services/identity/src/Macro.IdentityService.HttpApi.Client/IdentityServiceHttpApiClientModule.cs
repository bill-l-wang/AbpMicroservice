using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Http.Client;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Macro.IdentityService;

[DependsOn(
    typeof(IdentityServiceApplicationContractsModule),
    typeof(AbpIdentityHttpApiClientModule)
)]
public class IdentityServiceHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(IdentityServiceApplicationContractsModule).Assembly,
            IdentityServiceRemoteServiceConsts.RemoteServiceName
        );
    }
}