using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface ICitiesManager
    {
        ICitiesDB CitiesDbObject { get; }

        List<City> GetCities();
        City GetCity(int id);
    }
}