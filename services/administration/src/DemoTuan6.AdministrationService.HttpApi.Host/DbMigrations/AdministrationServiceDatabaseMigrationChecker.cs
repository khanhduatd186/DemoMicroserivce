﻿using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using DemoTuan6.AdministrationService.EntityFrameworkCore;
using DemoTuan6.Shared.Hosting.Microservices.DbMigrations.EfCore;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.Distributed;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Uow;

namespace DemoTuan6.AdministrationService.DbMigrations;

public class AdministrationServiceDatabaseMigrationChecker : PendingEfCoreMigrationsChecker<AdministrationServiceDbContext>
{
    private readonly AdministrationServiceDataSeeder _administrationServiceDataSeeder;

    public AdministrationServiceDatabaseMigrationChecker(
        ILoggerFactory loggerFactory,
        IUnitOfWorkManager unitOfWorkManager,
        IServiceProvider serviceProvider,
        ICurrentTenant currentTenant,
        IDistributedEventBus distributedEventBus,
        IAbpDistributedLock abpDistributedLock,
        AdministrationServiceDataSeeder administrationServiceDataSeeder) : base(
        loggerFactory,
        unitOfWorkManager,
        serviceProvider,
        currentTenant,
        distributedEventBus,
        abpDistributedLock,
        AdministrationServiceDbProperties.ConnectionStringName)
    {
        _administrationServiceDataSeeder = administrationServiceDataSeeder;
    }

    public override async Task CheckAndApplyDatabaseMigrationsAsync()
    {
        await base.CheckAndApplyDatabaseMigrationsAsync();

        await TryAsync(async () => await _administrationServiceDataSeeder.SeedAsync());
    }
}