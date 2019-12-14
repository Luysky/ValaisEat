using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDishesManager
    {

        List<Dish> GetDishes(int id);
        Dish GetDish(int id);
    }
}