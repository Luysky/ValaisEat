using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IOrdersManager
    {
        

        List<Order> GetOrders(int id);
        Order GetOrder(int id);
        Order AddOrder(Order order);
        int UpdateOrder(Order order);
        int DeleteOrder(int id);
    }
}