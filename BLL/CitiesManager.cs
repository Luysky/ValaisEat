using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class CitiesManager : ICitiesManager

    {
        public ICitiesDB CitiesDbObject => throw new NotImplementedException();

        public List<City> GetCities()
        {
            throw new NotImplementedException();
        }

        public City GetCity(int id)
        {
            throw new NotImplementedException();
        }
    }
}
