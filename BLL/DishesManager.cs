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

     
        public Dish GetDish(int id)
        {
            return DishesDbObject.GetDish(id);
        }

        public List<Dish> GetDishes(int id)
        {
            return DishesDbObject.GetDishes(id);
        }

     
    }
}
