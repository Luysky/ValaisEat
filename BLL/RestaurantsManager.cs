using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class RestaurantsManager : IRestaurantsManager
    {
        private IRestaurantsDB RestaurantsDbObject { get; }

        public RestaurantsManager(IRestaurantsDB restaurantsDB)
        {
            RestaurantsDbObject = restaurantsDB;
        }

        public List<Restaurant> GetRestaurants(int id)
        {
            return RestaurantsDbObject.GetRestaurants(id);
        }
    }
}
