using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    internal interface IOrderDishesManager
    {
        IOrderDishesDB OrderDishesObject { get; }

        List<OrderDish> GetOrderDishes();
        OrderDish GetOrderDish(int id);
        OrderDish AddOrderDish(OrderDish orderDish);

        int UpdateOrderDish(OrderDish orderDish);
        int DeleteOrderDish(int id);
    }
}