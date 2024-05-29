using Volo.Abp.Modularity;

namespace DemoTuan6.AdministrationService;

[DependsOn(
    typeof(AdministrationServiceApplicationModule),
    typeof(AdministrationServiceDomainTestModule)
    )]
public class AdministrationServiceApplicationTestModule : AbpModule
{

}
