using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services;
using DataLayer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<ICategoryService, CategoryService>()
            .AddSingleton<IManufacturerService, ManufacturerService>()
            .AddSingleton<IOrderService, OrderService>()
            .AddSingleton<IProductService, ProductService>()
            .AddDbContext<EShopContext>()
            .AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
