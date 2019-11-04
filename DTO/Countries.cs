using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Countries
    {
        public int IdCountry { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{IdCountry}|{Name}";
        }
    }
}
