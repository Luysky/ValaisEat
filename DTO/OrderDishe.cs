using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderDishe
    {
        public int IdOrder { get; set; }
        public int IdDish { get; set; }
        public int Quantity { get; set; }
        public double OrderDishPrice { get; set; }

        public override string ToString()
        {
            return $"{IdOrder}|{IdDish}|{Quantity}|{OrderDishPrice}";
        }
    }
}
