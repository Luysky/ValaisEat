using DTO;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface ICitiesDB
    {
        List<City> GetCities(int id);
        City GetCity(int id);
    }
}
