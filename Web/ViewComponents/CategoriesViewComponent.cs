using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Services;

namespace Web.ViewComponents
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoriesViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync() => View(_categoryService.GetCategories());
    }
}
