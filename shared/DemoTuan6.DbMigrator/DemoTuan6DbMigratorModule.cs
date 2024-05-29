using DemoTuan6.AdministrationService;
using DemoTuan6.AdministrationService.EntityFrameworkCore;
using DemoTuan6.IdentityService;
using DemoTuan6.IdentityService.EntityFrameworkCore;
using DemoTuan6.ProductService;
using DemoTuan6.ProductService.EntityFrameworkCore;
using DemoTuan6.SaasService;
using DemoTuan6.SaasService.EntityFrameworkCore;
using DemoTuan6.Shared.Hosting;
using Volo.Abp.Modularity;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;

namespace DemoTuan6.DbMigrator;

[DependsOn(
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(DemoTuan6SharedHostingModule),
    typeof(IdentityServiceEntityFrameworkCoreModule),
    typeof(IdentityServiceApplicationContractsModule),
    typeof(SaasServiceEntityFrameworkCoreModule),
    typeof(SaasServiceApplicationContractsModule),
    typeof(AdministrationServiceEntityFrameworkCoreModule),
    typeof(AdministrationServiceApplicationContractsModule),
    typeof(ProductServiceApplicationContractsModule),
    typeof(ProductServiceEntityFrameworkCoreModule)
)]
public class DemoTuan6DbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpDistributedCacheOptions>(options => { options.KeyPrefix = "DemoTuan6:"; });
    }
}
