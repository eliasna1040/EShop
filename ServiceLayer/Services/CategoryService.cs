using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.DTOs;
using ServiceLayer.ExtensionMethods;
using ServiceLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly EShopContext _context;

        public CategoryService(EShopContext context)
        {
            _context = context;
        }

        public Page<CategoryModel> GetCategories(int start, int count)
        {
            IQueryable<Category> query = _context.Categories.AsNoTracking();

            return new Page<CategoryModel> { CurrentPage = start, Items = query.Page(start, count).Select(x => new CategoryModel(x)).ToList(), PageSize = count, Total = query.Count() };
        }

        public CategoryModel AddCategory(string category)
        {
            Category addedCategory = new Category { Name = category };
            _context.Categories.Add(addedCategory);
            _context.SaveChanges();
            _context.Entry(addedCategory).Reload();
            return new CategoryModel(addedCategory);
        }

        public CategoryModel? DisableCategory(int categoryId)
        {
            Category? category = _context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category == null)
                return null;

            category.Disabled = !category.Disabled;
            _context.SaveChanges();

            return new CategoryModel(category);
        }
    }
}
