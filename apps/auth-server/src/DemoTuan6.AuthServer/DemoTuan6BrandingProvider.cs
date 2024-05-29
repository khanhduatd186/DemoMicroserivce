using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace DemoTuan6.AuthServer;

[Dependency(ReplaceServices = true)]
public class DemoTuan6BrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "DemoTuan6";
}
