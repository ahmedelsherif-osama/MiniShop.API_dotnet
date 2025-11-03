using Microsoft.EntityFrameworkCore;
using MiniShopAPI.Models;
using MiniShopAPI.Models.Payments;



public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Payment> Payments => Set<Payment>();
}