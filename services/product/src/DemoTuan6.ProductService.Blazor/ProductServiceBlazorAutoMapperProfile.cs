using AutoMapper;
using DemoTuan6.ProductService.Products;

namespace DemoTuan6.ProductService.Blazor;

public class ProductServiceBlazorAutoMapperProfile : Profile
{
    public ProductServiceBlazorAutoMapperProfile()
    {
        CreateMap<ProductDto, ProductUpdateDto>().MapExtraProperties();
    }
}
