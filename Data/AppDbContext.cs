using Microsoft.EntityFrameworkCore;
using MiniShopAPI.Models;

class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
}