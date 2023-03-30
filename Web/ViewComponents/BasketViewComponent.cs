using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.ViewComponents
{
    public class BasketViewComponent : ViewComponent
    {
        private readonly IProductService _productService;

        public BasketViewComponent(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            List<Product> products = new();
            string[]? strings = HttpContext.Request.Cookies["Products"]?.Split(',');
            if (strings != null)
            {
                foreach (var item in strings)
                {
                    if (int.TryParse(item, out int productId))
                    {
                        products.Add(_productService.GetProduct(productId));
                    }
                }
            }
            
            return View(products);
        }
    }
}
