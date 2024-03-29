﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class OrderDish
    {
        public int IdOrder { get; set; }
        public int IdDish { get; set; }
        public int Quantity { get; set; }
        public decimal OrderDishPrice { get; set; }

        public override string ToString()
        {
            return $"{IdOrder}|{IdDish}|{Quantity}|{OrderDishPrice}";
        }
    }
}
