using DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class ManufacturerModel
    {
        public int? ManufacturerId { get; set; }
        public string? Name { get; set; }
        public bool? Disabled { get; set; }

        public ManufacturerModel(Manufacturer manufacturer)
        {
            ManufacturerId = manufacturer.ManufacturerId;
            Name = manufacturer.Name;
            Disabled = manufacturer.Disabled;
        }
    }
}
