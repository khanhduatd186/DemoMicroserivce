using AutoMapper;
using DemoTuan6.ProductService.Products;

namespace DemoTuan6.ProductService;

public class ProductServiceApplicationAutoMapperProfile : Profile
{
    public ProductServiceApplicationAutoMapperProfile()
    {
        CreateMap<Product, ProductDto>().MapExtraProperties();
    }
}
