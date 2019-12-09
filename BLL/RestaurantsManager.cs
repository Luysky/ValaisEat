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
        public IRestaurantsDB RestaurantsDbObject { get; }

        public RestaurantsManager(IConfiguration Configuration)
        {
            RestaurantsDbObject = new RestaurantsDB(Configuration);
        }

        //public IRestaurantsDB RestaurantsDbObjects => throw new NotImplementedException();

        public Restaurant GetRestaurant(int id)
        {
            throw new NotImplementedException();
        }

        public List<Restaurant> GetRestaurants()
        {
            throw new NotImplementedException();
        }
    }
}
