using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;

namespace DemoTuan6.IdentityService;

[DependsOn(
    typeof(AbpIdentityProDomainModule),
    typeof(AbpOpenIddictProDomainModule),
    typeof(IdentityServiceDomainSharedModule)
)]
public class IdentityServiceDomainModule : AbpModule
{
}
