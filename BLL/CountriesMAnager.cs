using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    class CountriesManager : ICountriesManager
    {
        public ICountriesDB CountriesDbObject => throw new NotImplementedException();

        public List<Country> GetCountries()
        {
            throw new NotImplementedException();
        }

        public Country GetCountry(int id)
        {
            throw new NotImplementedException();
        }
    }
}
