using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiniShopAPI.Models;

namespace MiniShopAPI.Services;

public class ProductService
{
    private readonly IProductRepository _repository;

    public ProductService(IProductRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Product>> GetAllAsync()
    {
        return _repository.GetAllAsync();
    }
    public Task<Product> GetByIdAsync(Guid id)
    {
        var product = _repository.GetByIdAsync(id);

        return product;
    }

    public Task AddAsync(Product product)
    {
        product.Id = Guid.NewGuid();
        return _repository.AddAsync(product);


    }

    public Task UpdateAsync(Product product)
    {
        var orginalProduct = _repository.UpdateAsync(product);
        return orginalProduct;


    }

    public Task DeleteAsync(Guid productId)
    {
        return _repository.DeleteAsync(productId);


    }
}