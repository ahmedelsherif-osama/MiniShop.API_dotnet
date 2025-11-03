using Microsoft.EntityFrameworkCore;
using MiniShopAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddScoped<ProductService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();


// app.UseHttpsRedirection();





app.Run();

