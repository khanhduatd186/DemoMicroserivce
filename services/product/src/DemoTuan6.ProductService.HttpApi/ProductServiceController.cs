using DemoTuan6.ProductService.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace DemoTuan6.ProductService;

public abstract class ProductServiceController : AbpController
{
    protected ProductServiceController()
    {
        LocalizationResource = typeof(ProductServiceResource);
    }
}
