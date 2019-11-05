using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dish
    {
        public int IdDish { get; set; }
        public string Name { get; set; }
        public double DishPrice { get; set; }
        public string Status { get; set; }
        public int IdRestaurant { get; set; }

        public override string ToString()
        {
            return $"{IdDish}|{Name}|{DishPrice}|{Status}|{IdRestaurant}";
        }

    }
}
