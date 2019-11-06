using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    internal interface ICountriesManager
    {
        ICountriesDB CountriesDbObject { get; }

        List<Country> GetCountries();

        Country GetCountry(int id);
    }
}