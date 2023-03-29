using DataLayer.Entities;

namespace ServiceLayer.Services
{
    public interface ICategoryService
    {
        void AddCategory(string category);
        void DisableCategory(int categoryId);
        List<Category> GetCategories();
    }
}