using Microsoft.EntityFrameworkCore;
using MiniShopAPI.Models;
using MiniShopAPI.Models.Payments;



public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Payment> Payments => Set<Payment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Payment>()
        .HasDiscriminator<string>("PaymentType")
        .HasValue<CashPayment>("Cash")
        .HasValue<CardPayment>("Card")
        .HasValue<WalletPayment>("Wallet")
        .HasValue<CryptoPayment>("Crypto");
    }
}