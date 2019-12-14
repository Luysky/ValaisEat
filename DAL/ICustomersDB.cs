﻿using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface ICustomersDB
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
        int UpdateCustomer(Customer customer);

    }
}
