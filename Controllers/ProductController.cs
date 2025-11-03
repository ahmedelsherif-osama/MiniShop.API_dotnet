using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MiniShopAPI.Models;
using MiniShopAPI.Services;

namespace MiniShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {
        this._productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAll()
    {
        return await _productService.GetAllAsync();
    }

    [HttpGet("{productId}")]
    public async Task<ActionResult<Product>> GetProductById(Guid productId)
    {
        return await _productService.GetByIdAsync(productId);
    }

    [HttpPost]

    public async Task<ActionResult<Product>> AddProduct([FromBody] Product product)
    {
        await _productService.AddAsync(product);
        return product;
    }

    [HttpPut]
    public async Task<ActionResult<Product>> UpdateProduct([FromBody] Product product)
    {
        await _productService.UpdateAsync(product);
        return product;
    }

    [HttpDelete("{productId}")]
    public async Task<IActionResult> DeleteProduct(Guid productId)
    {
        await _productService.DeleteAsync(productId);
        return Ok();
    }
}

