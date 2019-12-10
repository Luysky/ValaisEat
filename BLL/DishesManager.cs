using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    
    public class DishesManager : IDishesManager
    {

        private IDishesDB DishesDbObject { get; }


        public DishesManager(IDishesDB dishesDB)
        {
            DishesDbObject = dishesDB;
        }

        public Dish AddDish(Dish dish)
        {
            return DishesDbObject.AddDish(dish);
        }

        public int DeleteDish(int id)
        {
            return DishesDbObject.DeleteDish(id);
        }

        public Dish GetDish(int id)
        {
            return DishesDbObject.GetDish(id);
        }

        public List<Dish> GetDishes(int id)
        {
            return DishesDbObject.GetDishes(id);
        }

        public int UpdateDish(Dish dish)
        {
            return DishesDbObject.UpdateDish(dish);
        }
    }
}
