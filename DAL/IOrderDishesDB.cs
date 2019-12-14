using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrderDishesDB
    {
        List<OrderDish> GetOrderDishes(int id);
        OrderDish GetOrderDish(int idOrder, int idDish);
        void AddOrderDish(OrderDish orderDish);

        int UpdateOrderDish(OrderDish orderDish);
        int DeleteOrderDish(int id);
        void DeleteOrderDish(int idOrder, int idDish);
    }
}
