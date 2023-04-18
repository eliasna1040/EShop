using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Models
{
    public class CheckOutCard
    {
        [Required, MaxLength(16)]
        public string CardNumber { get; set; }
        [Required]
        public string ExpireDate { get; set; }
        [Required, MaxLength(3)]
        public string SecurityNumber { get; set; }
    }
}
