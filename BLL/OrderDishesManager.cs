using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    class OrderDishesManager : IOrderDishesManager
    {
        public IOrderDishesDB OrderDishesObject => throw new NotImplementedException();

        public OrderDish AddOrderDish(OrderDish orderDish)
        {
            throw new NotImplementedException();
        }

        public int DeleteOrderDish(int id)
        {
            throw new NotImplementedException();
        }

        public OrderDish GetOrderDish(int id)
        {
            throw new NotImplementedException();
        }

        public List<OrderDish> GetOrderDishes()
        {
            throw new NotImplementedException();
        }

        public int UpdateOrderDish(OrderDish orderDish)
        {
            throw new NotImplementedException();
        }
    }
}
