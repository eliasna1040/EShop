using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class ProductModel
    {
        public int? ProductId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public bool Disabled { get; set; } = false;
        public string? Image { get; set; }
        [Required]
        public int? ManufacturerId { get; set; }
        public ManufacturerModel? Manufacturer { get; set; }
        [Required]
        public int? CategoryId { get; set; }
        public CategoryModel? Category { get; set; }
    }
}
