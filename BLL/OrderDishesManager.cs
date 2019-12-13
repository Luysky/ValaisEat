using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class OrderDishesManager : IOrderDishesManager
    {
        private IOrderDishesDB OrderDishesDbObject { get; }

        public OrderDishesManager (IOrderDishesDB orderDishesDB)
        {
            OrderDishesDbObject = orderDishesDB;
        }


        public void AddOrderDish(OrderDish orderDish)
        {
            OrderDishesDbObject.AddOrderDish(orderDish);
        }

        public int DeleteOrderDish(int id)
        {
            return OrderDishesDbObject.DeleteOrderDish(id);
        }

        public int DeleteOrderDish(int idOrder, int idDish)
        {
            return OrderDishesDbObject.DeleteOrderDish(idOrder, idDish);
        }

        public OrderDish GetOrderDish(int id)
        {
            return OrderDishesDbObject.GetOrderDish(id);
        }

        public List<OrderDish> GetOrderDishes(int id)
        {
            return OrderDishesDbObject.GetOrderDishes(id);
        }

        public int UpdateOrderDish(OrderDish orderDish)
        {
            return OrderDishesDbObject.UpdateOrderDish(orderDish);
        }
    }
}
