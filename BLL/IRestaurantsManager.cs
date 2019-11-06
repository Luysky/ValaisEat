using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    internal interface IRestaurantsManager
    {
        IRestaurantsDB RestaurantsDbObject { get; }

        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);

    }
}