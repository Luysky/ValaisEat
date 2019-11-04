using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Areas
    {
        public int IdArea { get; set; }
        public string Name { get; set; }
        public int IdCountry { get; set; }


        public override string ToString()
        {
            return $"{IdArea}|{Name}|{IdCountry}";
        }
    }
}
