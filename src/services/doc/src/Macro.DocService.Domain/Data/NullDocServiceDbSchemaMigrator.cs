using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace DocService.Data;

/* This is used if database provider does't define
 * IDocServiceDbSchemaMigrator implementation.
 */
public class NullDocServiceDbSchemaMigrator : IDocServiceDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
