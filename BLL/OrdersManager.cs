using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class OrdersManager : IOrdersManager
    {

        private IOrdersDB OrdersDbObject { get; }

        public OrdersManager (IOrdersDB ordersDB)
        {
            OrdersDbObject = ordersDB;
        }

        

        public Order AddOrder(Order order)
        {
            return OrdersDbObject.AddOrder(order);
        }

        public int DeleteOrder(int id)
        {
            return OrdersDbObject.DeleteOrder(id);
        }

        public Order GetOrder(int id)
        {
            return OrdersDbObject.GetOrder(id);
        }

        public List<Order> GetOrders(int id)
        {
            var orders = OrdersDbObject.GetOrders(id);
            foreach (var o in orders)
            {
                if (o.Status != "Deliver in Progress")
                    orders.Remove(o);
            }

            return orders;
        }

        public int UpdateOrder(Order order)
        {
            return OrdersDbObject.UpdateOrder(order);
        }
    }
}
