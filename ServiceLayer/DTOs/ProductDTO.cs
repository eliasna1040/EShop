using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int CategoryId { get; set; }
        public int ManufacturerId { get; set; }
        public byte[] Image { get; set; }
        public bool Disabled { get; set; }
    }
}
