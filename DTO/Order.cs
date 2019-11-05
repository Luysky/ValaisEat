using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string Status { get; set; }
        public double OrderPrice { get; set; }
        public int IdCustomer { get; set; }
        public int IdDeliver { get; set; }

        public override string ToString()
        {
            return $"{IdOrder}|{Status}|{OrderPrice}|{IdCustomer}|{IdDeliver}";
        }
    }
}
