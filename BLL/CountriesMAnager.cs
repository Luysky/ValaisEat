using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class CountriesManager : ICountriesManager
    {

        private ICountriesDB CountriesDbObject { get; }

        public CountriesManager (ICountriesDB countriesDB)
        {
            CountriesDbObject = countriesDB;
        }

        
        public List<Country> GetCountries()
        {
            return CountriesDbObject.GetCountries();
        }
        

        public Country GetCountry(int id)
        {
            return CountriesDbObject.GetCountry(id);
        }
    }
}
