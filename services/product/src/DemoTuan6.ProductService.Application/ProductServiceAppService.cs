using DemoTuan6.ProductService.Localization;
using Volo.Abp.Application.Services;

namespace DemoTuan6.ProductService;

public abstract class ProductServiceAppService : ApplicationService
{
    protected ProductServiceAppService()
    {
        LocalizationResource = typeof(ProductServiceResource);
        ObjectMapperContext = typeof(ProductServiceApplicationModule);
    }
}
