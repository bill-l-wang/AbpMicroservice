using Volo.Abp.Modularity;

namespace DocService;

/* Inherit from this class for your domain layer tests. */
public abstract class DocServiceDomainTestBase<TStartupModule> : DocServiceTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
