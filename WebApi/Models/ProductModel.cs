using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace WebApi.Models
{
    public class ProductModel
    {
        public int? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public bool? Disabled { get; set; }
        public byte[]? Image { get; set; }
        public ManufacturerModel? Manufacturer { get; set; }
        public CategoryModel? Category { get; set; }

        public ProductModel(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            Disabled = product.Disabled;
            Image = product.Image?.ImageData;
            Manufacturer = product.Manufacturer != null ? new ManufacturerModel(product.Manufacturer) : null;
            Category = product.Category != null ? new CategoryModel(product.Category) : null;
        }
    }
}
