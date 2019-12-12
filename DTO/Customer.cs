﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
        public int IdCity { get; set; }

        public override string ToString()
        {
            return $"{IdCustomer}|{Name}|{Adresse}|{IdCity}";
        }
    }
}
