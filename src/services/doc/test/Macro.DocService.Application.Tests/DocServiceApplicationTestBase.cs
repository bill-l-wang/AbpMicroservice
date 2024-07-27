using Volo.Abp.Modularity;

namespace DocService;

public abstract class DocServiceApplicationTestBase<TStartupModule> : DocServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
