﻿using Volo.Abp.Modularity;
using Volo.Saas;

namespace DemoTuan6.SaasService;

[DependsOn(
    typeof(SaasServiceDomainSharedModule),
    typeof(SaasDomainModule)
)]
public class SaasServiceDomainModule : AbpModule
{
}
