using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Manufacturer
    {
        [Required]
        public int ManufacturerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public bool Disabled { get; set; } = false;

        public ICollection<Product> Products { get; set; }
    }
}
