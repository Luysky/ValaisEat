using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrderDishesDB
    {
        List<OrderDish> GetOrderDishes(int id);
        OrderDish GetOrderDish(int id);
        OrderDish AddOrderDish(OrderDish orderDish);

        int UpdateOrderDish(OrderDish orderDish);
        int DeleteOrderDish(int id);
        int DeleteOrderDish(int idOrder, int idDish);
    }
}
