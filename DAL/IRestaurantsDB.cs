using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IRestaurantsDB
    {
        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);

    }
}
