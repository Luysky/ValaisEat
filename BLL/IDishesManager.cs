using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDishesManager
    {
        

        List<Dish> GetDishes();
        Dish GetDish(int id);
        Dish AddDish(Dish dish);
        int UpdateDish(Dish dish);
        int DeleteDish(int id);
    }
}