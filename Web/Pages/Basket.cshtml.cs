using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer.Services;
using Web.JsonObjects;
using Web.Models;

namespace Web.Pages
{
    public class BasketModel : PageModel
    {
        public List<BasketItem> BasketItems { get; set; } = new List<BasketItem>();

        private readonly ILogger<BasketModel> _logger;
        private readonly IProductService _productService;

        public BasketModel(ILogger<BasketModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public void OnGet()
        {
            ViewData["Basket"] = true;
            string? cookie = HttpContext.Request.Cookies["Products"];
            if (cookie != null)
            {
                foreach (BasketJson item in JsonConvert.DeserializeObject<List<BasketJson>>(cookie))
                {
                    Product? product = _productService.GetProduct(item.ProductId);
                    if (product != null)
                    {
                        BasketItems.Add(new BasketItem { Id = item.ProductId, Name = product.Name, Description = product.Description, Amount = item.Amount, Price = product.Price });
                    }
                }
            }
        }
    }
}
