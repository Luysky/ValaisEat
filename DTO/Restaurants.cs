using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Restaurants
    {
        public int IdRestaurant { get; set; }
        public string Name { get; set; }
        public int IdCity { get; set; }

        public override string ToString()
        {
            return $"{IdRestaurant}|{Name}|{IdCity}";
        }
    }
}
