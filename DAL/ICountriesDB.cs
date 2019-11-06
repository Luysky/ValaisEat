using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface ICountriesDB
    {
        List<Country> GetCountries();

        Country GetCountry(int id);
    }
}
