using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTOs;
using ServiceLayer.Services;
using ServiceLayer.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories(int start = 1, int count = 10)
        {
            return Ok(_categoryService.GetCategories(start, count));
        }

        [HttpPost]
        public IActionResult AddCategory(string category)
        {
            CategoryModel? addedCategory = _categoryService.AddCategory(category);
            if (addedCategory != null)
            {
                return Ok(addedCategory);
            }

            return BadRequest();
        }

        [HttpPut("{id}")]
        public IActionResult DisableCategory(int id)
        {
            CategoryModel? category = _categoryService.DisableCategory(id);
            if (category != null)
            {
                return Ok(category);
            }

            return BadRequest();
        }
    }
}
