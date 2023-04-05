﻿using DataLayer.Entities;
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
            string? cookie = HttpContext.Request.Cookies["Products"];
            if (cookie != null)
            {
                foreach (BasketJson item in JsonConvert.DeserializeObject<List<BasketJson>>(cookie))
                {
                    products.Add(_productService.GetProduct(item.ProductId));
                }
            }

            return View(products);
        }
    }
}
