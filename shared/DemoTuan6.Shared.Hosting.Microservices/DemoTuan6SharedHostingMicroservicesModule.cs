using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Logging;
using DemoTuan6.AdministrationService.EntityFrameworkCore;
using DemoTuan6.SaasService.EntityFrameworkCore;
using DemoTuan6.Shared.Hosting.AspNetCore;
using StackExchange.Redis;
using Volo.Abp.AspNetCore.Authentication.JwtBearer;
using Volo.Abp.AspNetCore.Authentication.JwtBearer.DynamicClaims;
using Volo.Abp.AspNetCore.MultiTenancy;
using Volo.Abp.BackgroundJobs.RabbitMQ;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.EventBus.RabbitMq;
using Volo.Abp.Modularity;
// using Volo.Abp.MongoDB;
using Volo.Abp.MultiTenancy;

namespace DemoTuan6.Shared.Hosting.Microservices;

[DependsOn(
    // typeof(AbpMongoDbModule), // Un-comment if you are using mongodb in any microservice
    typeof(DemoTuan6SharedHostingAspNetCoreModule),
    typeof(AbpBackgroundJobsRabbitMqModule),
    typeof(AbpAspNetCoreAuthenticationJwtBearerModule),
    typeof(AbpAspNetCoreMultiTenancyModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpEventBusRabbitMqModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule)
)]
public class DemoTuan6SharedHostingMicroservicesModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<WebRemoteDynamicClaimsPrincipalContributorOptions>(options =>
        {
            options.IsEnabled = true;
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();
        var hostingEnvironment = context.Services.GetHostingEnvironment();

        Configure<AbpMultiTenancyOptions>(options =>
        {
            options.IsEnabled = true;
        });

        Configure<AbpDistributedCacheOptions>(options =>
        {
            options.KeyPrefix = "DemoTuan6:";
        });

        var redis = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]!);

        context.Services
            .AddDataProtection()
            .SetApplicationName("DemoTuan6")
            .PersistKeysToStackExchangeRedis(redis, "DemoTuan6-Protection-Keys");

        context.Services.AddSingleton<IDistributedLockProvider>(_ =>
            new RedisDistributedSynchronizationProvider(redis.GetDatabase()));

        if (hostingEnvironment.IsDevelopment())
        {
            IdentityModelEventSource.ShowPII = true;
        }

        context.Services.AddHttpClient();
    }
}
