using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    class OrdersManager : IOrdersManager
    {
        public IOrdersDB OrdersDbObject => throw new NotImplementedException();

        public Order AddOrder(Order order)
        {
            throw new NotImplementedException();
        }

        public int DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Order GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetOrders()
        {
            throw new NotImplementedException();
        }

        public int UpdateOrder(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
