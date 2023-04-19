using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DTOs
{
    public class UserDTO
    {
        public int? Id { get; set; }
        public bool IsAdmin { get; set; }
    }
}
