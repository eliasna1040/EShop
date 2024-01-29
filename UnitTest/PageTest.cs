using DataLayer;
using DataLayer.Entities;
using Microsoft.Extensions.Logging;
using ServiceLayer.Services;
using Web.Pages;

namespace UnitTest;

public class PageTest
{
    [Fact]
    public void LoadIndexTest()
    {
        using EShopContext context = ContextCreater.CreateContext("ToDo");

        for (int i = 0; i < 20; i++)
        {
            context.Products.Add(new Product
            {
                Name = "G63 AMG", Description = "det er en bil", Price = 2500000,
                Category = new Category { Name = "Bil" }, Manufacturer = new Manufacturer { Name = "Mercedes-Benz" }
            });
        }

        context.SaveChanges();

        int count = context.Products.Count();

        IndexModel indexModel =
            new IndexModel(new Logger<IndexModel>(new LoggerFactory()), new ProductService(context));

        indexModel.OnGet();

        Assert.Equal(20, indexModel.Products.Count);
    }
}