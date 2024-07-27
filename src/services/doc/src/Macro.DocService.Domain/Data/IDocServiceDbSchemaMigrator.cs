using System.Threading.Tasks;

namespace DocService.Data;

public interface IDocServiceDbSchemaMigrator
{
    Task MigrateAsync();
}
