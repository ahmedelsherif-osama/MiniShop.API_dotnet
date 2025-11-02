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
    public ActionResult<List<Product>> GetAll()
    {
        return _productService.GetAll();
    }

    [HttpGet("{productId}")]
    public ActionResult<Product> GetProductById(Guid productId)
    {
        return _productService.GetById(productId);
    }

    [HttpPost]

    public ActionResult<Product> AddProduct([FromBody] Product product)
    {
        _productService.Add(product);
        return product;
    }

    [HttpPut]
    public ActionResult<Product> UpdateProduct([FromBody] Product product)
    {
        _productService.Update(product);
        return product;
    }

    [HttpDelete("{productId}")]
    public IActionResult DeleteProduct(Guid productId)
    {
        _productService.Delete(productId);
        return Ok();
    }
}

