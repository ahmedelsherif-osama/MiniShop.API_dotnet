using MiniShopAPI.Models;

namespace MiniShopAPI.Services;

public class ProductService
{
    private readonly List<Product> _products = new();

    public List<Product> GetAll()
    {
        return _products;
    }
    public Product GetById(Guid id)
    {
        return _products.Where(p => p.Id == id).First();
    }

    public void Add(Product product)
    {
        product.Id = Guid.NewGuid();
        _products.Add(product);
    }

    public void Update(Product product)
    {
        var orginalProduct = _products.Where(p => p.Id == product.Id).First();
        _products.Remove(orginalProduct);
        _products.Add(product);
    }

    public void Delete(Guid productId)
    {
        var product = _products.Where(p => p.Id == productId).First();
        _products.Remove(product);
    }
}