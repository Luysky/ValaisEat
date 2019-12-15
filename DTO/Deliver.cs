using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Deliver
    {
        public int IdDeliver { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public string PhoneNumber { get; set; }
        public int IdCity { get; set; }

        public override string ToString()
        {
            return $"{IdDeliver}|{Name}|{PhoneNumber}|{IdCity}";
        }
    }
}
