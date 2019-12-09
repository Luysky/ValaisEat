using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    internal interface IOrdersManager
    {
        

        List<Order> GetOrders();
        Order GetOrder(int id);
        Order AddOrder(Order order);
        int UpdateOrder(Order order);
        int DeleteOrder(int id);
    }
}