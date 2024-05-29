using Volo.Abp.Bundling;

namespace DemoTuan6.Blazor;

public class DemoTuan6BundleContributor : IBundleContributor
{
    public void AddScripts(BundleContext context)
    {
    }

    public void AddStyles(BundleContext context)
    {
        context.Add("main.css");
    }
}
