using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class CustomerLogin
    {
        public int IdLogin { get; set; }

        public int IdCustomer { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
