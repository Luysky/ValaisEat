using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    internal interface ICountriesManager
    {
        
        List<Country> GetCountries();

        Country GetCountry(int id);
    }
}