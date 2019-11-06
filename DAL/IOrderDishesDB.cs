using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IOrderDishesDB
    {
        List<OrderDish> GetOrderDishes();
        OrderDish GetOrderDish(int id);
        OrderDish AddOrderDish(OrderDish orderDish);

        int UpdateOrderDish(OrderDish orderDish);
        int DeleteOrderDish(int id);
    }
}
