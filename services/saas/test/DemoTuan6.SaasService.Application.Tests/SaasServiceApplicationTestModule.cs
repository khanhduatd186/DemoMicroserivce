using DemoTuan6.SaasService.Application;
using Volo.Abp.Modularity;

namespace DemoTuan6.SaasService;

[DependsOn(
    typeof(SaasServiceApplicationModule),
    typeof(SaasServiceDomainTestModule)
    )]
public class SaasServiceApplicationTestModule : AbpModule
{

}
