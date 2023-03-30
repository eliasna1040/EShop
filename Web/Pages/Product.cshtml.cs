using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services;

namespace Web.Pages
{
    public class ProductModel : PageModel
    {
        public Product? Product { get; set; }

        private readonly IProductService _productService;

        public ProductModel(IProductService productService)
        {
            _productService = productService;
        }

        public void OnGet(int productId)
        {
            Product = _productService.GetProduct(productId);
        }
    }
}
