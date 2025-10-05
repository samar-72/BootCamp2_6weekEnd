﻿using System.ComponentModel.DataAnnotations;

namespace BootCamp2_6weekEnd.Models
{
    public class Employee
    {

        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public string UserName { get; set; } 
        public string Password { get; set; }

    }
}
