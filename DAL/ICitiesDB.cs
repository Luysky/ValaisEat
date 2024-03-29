﻿using DTO;
using System;
using System.Collections.Generic;
using System.Text;


namespace DAL
{
    public interface ICitiesDB
    {
        List<City> GetCities();
        City GetCity(int id);
    }
}
