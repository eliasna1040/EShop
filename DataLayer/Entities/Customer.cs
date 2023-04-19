﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Customer
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [NotMapped]
        [Required, Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Address { get; set; }
        public bool Admin { get; set; } = false;
        [Required]
        public bool Disabled { get; set; } = false;

        public ICollection<Order> Orders { get; set; }
    }
}
