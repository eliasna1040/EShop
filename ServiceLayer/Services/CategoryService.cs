using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
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

        public List<Category> GetCategories()
        {
            return _context.Categories.AsNoTracking().ToList();
        }

        public void AddCategory(string category)
        {
            _context.Categories.Add(new Category { Name = category });
            _context.SaveChanges();
        }

        public void DisableCategory(int categoryId)
        {
            Category? category = _context.Categories.FirstOrDefault(x => x.CategoryId == categoryId);
            if (category == null)
                return;

            category.Disabled = !category.Disabled;
            _context.SaveChanges();
        }
    }
}
