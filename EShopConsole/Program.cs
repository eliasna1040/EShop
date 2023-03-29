using DataLayer;
using Microsoft.Extensions.DependencyInjection;
using ServiceLayer.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        ServiceProvider serviceProvider = new ServiceCollection()
            .AddSingleton<ICategoryService, CategoryService>()
            .AddSingleton<IManufacturerService, ManufacturerService>()
            .AddSingleton<IOrderService, OrderService>()
            .AddSingleton<IProductService, ProductService>()
            .AddDbContext<EShopContext>()
            .BuildServiceProvider();

        serviceProvider.GetService<ICategoryService>().GetCategories();
    }
}