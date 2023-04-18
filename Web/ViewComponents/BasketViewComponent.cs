using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ServiceLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.JsonObjects;

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
            if (HttpContext.Request.Cookies.TryGetValue("Products", out string? cookie))
            {
                List<BasketJson>? basket = JsonConvert.DeserializeObject<List<BasketJson>>(cookie!);
                if (basket != null)
                {
                    foreach (BasketJson item in basket)
                    {
                        Product? product = _productService.GetProduct(item.ProductId);
                        if (product != null)
                        {
                            products.Add(product);
                        }
                    }
                }
            }

            return View(products);
        }
    }
}
