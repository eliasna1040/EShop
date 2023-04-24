using DataLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Enums;
using ServiceLayer.Services;
using ServiceLayer.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetPage(string? search, int? categoryId, [FromQuery] int[]? manufacturerIds, OrderByEnum? orderBy, int page = 1, int count = 10)
        {
            return Ok(_productService.GetProducts(page, count, search, categoryId, manufacturerIds, orderBy));
        }

        [HttpPost]
        public IActionResult AddProduct([FromQuery] ProductDTO product, IFormFile? image)
        {
            try
            {
                byte[]? bytes = null;
                if (image != null)
                {
                    using MemoryStream ms = new MemoryStream();
                    image.CopyTo(ms);
                    bytes = ms.ToArray();
                }

                return Ok(_productService.AddProduct(product, bytes));
            }
            catch (Exception)
            {

                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            ProductModel? product = _productService.GetProduct(id);
            if (product != null)
            {
                return Ok(product);
            }

            return BadRequest();
        }

        [HttpPatch("{id}")]
        public IActionResult EditProduct(int id, [FromBody] JsonPatchDocument<Product> product)
        {
            try
            {
                return Ok(_productService.EditProduct(id, product));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult DisableProduct(int id)
        {
            try
            {
                return Ok(_productService.DisableProduct(id));
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
