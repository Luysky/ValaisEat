using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IRestaurantsManager
    {
        

        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);

    }
}