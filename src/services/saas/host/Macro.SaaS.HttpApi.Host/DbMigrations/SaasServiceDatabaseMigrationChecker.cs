using System;
using Macro.Saas.EntityFrameworkCore;
using Macro.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace Macro.Saas.DbMigrations;

public class SaasServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<SaasDbContext>
{
    public SaasServiceDatabaseMigrationChecker(
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
            SaasServiceDbProperties.ConnectionStringName)
    {
    }
}