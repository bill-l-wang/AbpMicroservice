using DocService.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace DocService.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DocServiceEntityFrameworkCoreModule),
    typeof(DocServiceApplicationContractsModule)
)]
public class DocServiceDbMigratorModule : AbpModule
{
}
