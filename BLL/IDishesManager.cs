using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    internal interface IDishesManager
    {
        IDishesDB DishesDbObject { get; }

        List<Dish> GetDishes();
        Dish GetDish(int id);
        Dish AddDish(Dish dish);
        int UpdateDish(Dish dish);
        int DeleteDish(int id);
    }
}