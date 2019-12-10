using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IRestaurantsDB
    {
        List<Restaurant> GetRestaurants(int id);
        Restaurant GetRestaurant(int id);

    }
}
