using Volo.Abp.Modularity;

namespace DocService;

[DependsOn(
    typeof(DocServiceDomainModule),
    typeof(DocServiceTestBaseModule)
)]
public class DocServiceDomainTestModule : AbpModule
{

}
