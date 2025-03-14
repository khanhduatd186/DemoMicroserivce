using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoTuan6.ProductService.Products;

namespace DemoTuan6.ProductService.Web.Pages.Products;

public class EditModalModel : ProductServicePageModel
{
    [HiddenInput]
    [BindProperty(SupportsGet = true)]
    public Guid Id { get; set; }

    [BindProperty]
    public ProductUpdateDto Product { get; set; } = default!;

    private readonly IProductAppService _productAppService;

    public EditModalModel(IProductAppService productAppService)
    {
        _productAppService = productAppService;
    }

    public async Task OnGetAsync()
    {
        var product = await _productAppService.GetAsync(Id);
        Product = ObjectMapper.Map<ProductDto, ProductUpdateDto>(product);
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await _productAppService.UpdateAsync(Id, Product);
        return NoContent();
    }
}
