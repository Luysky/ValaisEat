using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IOrderDishesManager
    {
     

        List<OrderDish> GetOrderDishes(int id);
        OrderDish GetOrderDish(int id);
        void AddOrderDish(OrderDish orderDish);

        int UpdateOrderDish(OrderDish orderDish);
        int DeleteOrderDish(int id);

        void DeleteOrderDish(int idOrder, int idDish);
    }
}