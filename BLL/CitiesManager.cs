﻿using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class CitiesManager : ICitiesManager

    {

        private ICitiesDB CitiesDbObject { get; }


        public CitiesManager(ICitiesDB citiesDB)
        {
            CitiesDbObject = citiesDB;
        }


        public List<City> GetCities()
        {
            return CitiesDbObject.GetCities();
        }

        public City GetCity(int id)
        {
           
            return CitiesDbObject.GetCity(id);
            
        }
    }
}
