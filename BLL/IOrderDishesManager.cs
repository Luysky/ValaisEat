using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IOrderDishesManager
    {
     

        List<OrderDish> GetOrderDishes(int id);
        OrderDish GetOrderDish(int id);
        OrderDish AddOrderDish(OrderDish orderDish);

        int UpdateOrderDish(OrderDish orderDish);
        int DeleteOrderDish(int id);

        int DeleteOrderDish(int idOrder, int idDish);
    }
}