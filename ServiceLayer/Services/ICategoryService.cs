using DataLayer.Entities;
using ServiceLayer.DTOs;
using ServiceLayer.ViewModels;

namespace ServiceLayer.Services
{
    public interface ICategoryService
    {
        CategoryModel AddCategory(string category);
        CategoryModel? DisableCategory(int categoryId);
        List<CategoryModel> GetCategories();
    }
}