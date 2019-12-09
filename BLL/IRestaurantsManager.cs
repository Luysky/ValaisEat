﻿using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    internal interface IRestaurantsManager
    {
        

        List<Restaurant> GetRestaurants();
        Restaurant GetRestaurant(int id);

    }
}