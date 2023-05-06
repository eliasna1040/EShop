using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Models
{
    public class ManufacturerModel
    {
        public int? ManufacturerId { get; set; }
        public string? Name { get; set; }
        public bool? Disabled { get; set; }
    }
}
