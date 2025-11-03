using Microsoft.EntityFrameworkCore;
using MiniShopAPI.Models;

public interface IProductRepository
{
    public Task<List<Product>> GetAllAsync();
    public Task<Product> GetByIdAsync(Guid id);
    public Task AddAsync(Product product);
    public Task UpdateAsync(Product product);
    public Task DeleteAsync(Guid productId);

}

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.Products.ToListAsync();
    }
    public async Task<Product> GetByIdAsync(Guid id)
    {
        var product = await _context.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
        if (product == null)
        {
            throw new Exception("Product not found!");
        }
        return product;
    }

    public async Task AddAsync(Product product)
    {
        product.Id = Guid.NewGuid();
        await _context.Products.AddAsync(product);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        var orginalProduct = await _context.Products.Where(p => p.Id == product.Id).FirstOrDefaultAsync();
        if (orginalProduct == null)
        {
            throw new Exception("Product not found!");
        }
        _context.Entry(orginalProduct).CurrentValues.SetValues(product);
        await _context.SaveChangesAsync();

    }

    public async Task DeleteAsync(Guid productId)
    {
        var product = await _context.Products.Where(p => p.Id == productId).FirstOrDefaultAsync();
        if (product == null)
        {
            throw new Exception("Product not found!");
        }
        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

    }
}