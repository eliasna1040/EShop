using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs
{
    public class ProductDTO
    {
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Feltet skal udfyldes")]
        public int ManufacturerId { get; set; }
        public byte[]? Image { get; set; }
        public bool Disabled { get; set; }
    }
}
