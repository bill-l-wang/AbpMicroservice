using System;
using DocService.EntityFrameworkCore;
using Macro.IdentityService;
using Macro.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Macro.Projects.DbMigrations;

public class DocServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<DocServiceDbContext>
{
    public DocServiceDatabaseMigrationChecker(
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock)
        : base(
            unitOfWorkManager,
            serviceProvider,
            currentTenant,
            distributedEventBus,
            abpDistributedLock,
            DocServiceDbProperties.ConnectionStringName)
    {
    }
}