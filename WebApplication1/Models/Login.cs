using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class Login
    {
       //private Customer custom;

        [Required]
        public string Email;

        [Required]
        public string Password;

    }
}
