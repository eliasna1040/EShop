using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class CategoryModel
    {
        public int? CategoryId { get; set; }
        public string? Name { get; set; }
        public bool? Disabled { get; set; }

        public CategoryModel(Category category)
        {
            CategoryId = category.CategoryId;
            Name = category.Name;
            Disabled = category.Disabled;
        }
    }
}
