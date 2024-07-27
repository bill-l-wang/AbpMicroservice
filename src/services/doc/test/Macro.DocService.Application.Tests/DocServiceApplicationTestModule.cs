using Volo.Abp.Modularity;

namespace DocService;

[DependsOn(
    typeof(DocServiceApplicationModule),
    typeof(DocServiceDomainTestModule)
)]
public class DocServiceApplicationTestModule : AbpModule
{

}
