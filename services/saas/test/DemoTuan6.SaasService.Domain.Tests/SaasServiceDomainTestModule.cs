﻿using Volo.Abp.Modularity;

namespace DemoTuan6.SaasService;

/* Domain tests are configured to use the EF Core provider.
 * You can switch to MongoDB, however your domain tests should be
 * database independent anyway.
 */
[DependsOn(
    typeof(SaasServiceDomainModule),
    typeof(SaasServiceTestBaseModule)
)]
public class SaasServiceDomainTestModule : AbpModule
{

}
