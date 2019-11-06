using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    class DishesManager : IDishesManager
    {
        public IDishesDB DishesDbObject => throw new NotImplementedException();

        public Dish AddDish(Dish dish)
        {
            throw new NotImplementedException();
        }

        public int DeleteDish(int id)
        {
            throw new NotImplementedException();
        }

        public Dish GetDish(int id)
        {
            throw new NotImplementedException();
        }

        public List<Dish> GetDishes()
        {
            throw new NotImplementedException();
        }

        public int UpdateDish(Dish dish)
        {
            throw new NotImplementedException();
        }
    }
}
