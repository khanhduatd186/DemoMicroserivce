using DemoTuan6.ProductService.Localization;
using Volo.Abp.AspNetCore.Components;

namespace DemoTuan6.ProductService.Blazor.Pages;

public class ProductServiceComponentBase : AbpComponentBase
{
    public ProductServiceComponentBase()
    {
        LocalizationResource = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceBlazorModule);
    }
}
