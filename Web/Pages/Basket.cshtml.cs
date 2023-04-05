using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using ServiceLayer.Services;
using Web.JsonObjects;

namespace Web.Pages
{
    public class BasketModel : PageModel
    {
        public List<Product> Products { get; set; } = new List<Product>();

        private readonly ILogger<BasketModel> _logger;
        private readonly IProductService _productService;

        public BasketModel(ILogger<BasketModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public void OnGet()
        {
            string? cookie = HttpContext.Request.Cookies["Products"];
            if (cookie != null)
            {
                foreach (BasketJson item in JsonConvert.DeserializeObject<List<BasketJson>>(cookie))
                {
                    Products.Add(_productService.GetProduct(item.ProductId));
                }
            }
        }
    }
}
