using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs
{
    public class ManufacturerDTO
    {
        public string Name { get; set; }
        public bool Disabled { get; set; } = false;
    }
}
