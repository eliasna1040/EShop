using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services;

namespace Web.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> Products { get; set; }

        private readonly ILogger<IndexModel> _logger;
        private readonly IProductService _productService;

        public IndexModel(ILogger<IndexModel> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public void OnGet(string? search = null, int? categoryId = null)
        {
            Products = _productService.GetProducts(1, 20, search, categoryId);
        }

        public IActionResult OnPostAddProduct(int productId)
        {
            Response.Cookies.Append("Products", $"{Request.Cookies["Products"]},{productId}", new CookieOptions() { Expires = DateTime.Now.AddDays(30)});
            return RedirectToPage();
        }
    }
}