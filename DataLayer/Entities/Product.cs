using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Product
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public int ManufacturerId { get; set; }
        [Required]
        public bool Disabled { get; set; } = false;
        public int? ImageId { get; set; }

        public Image? Image { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderProduct> OrdersProducts { get; set; }

    }
}
