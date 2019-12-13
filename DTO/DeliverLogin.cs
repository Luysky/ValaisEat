using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class DeliverLogin
    {

        public int IdLogin { get; set; }

        public int IdDeliver { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}
