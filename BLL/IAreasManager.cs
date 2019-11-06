﻿using System;
using System.Text;
using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    internal interface IAreasManager
    {
        IAreasDB AreasDbObject { get; }

        List<Area> GetAreas();
        Area GetArea(int id);
    }
}