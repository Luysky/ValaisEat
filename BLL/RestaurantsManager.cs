using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    class RestaurantsManager : IRestaurantsManager
    {
        public IRestaurantsDB RestaurantsDbObject => throw new NotImplementedException();

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
