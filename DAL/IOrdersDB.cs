﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IOrdersDB
    {
        List<Order> GetOrders();
        Order GetOrder(int id);
        Order AddOrder(Order order);
        int UpdateOrder(Order order);
        int DeleteOrder(int id);

    }
}
