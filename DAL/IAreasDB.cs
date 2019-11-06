using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    interface IAreasDB
    {
        List<Area> GetAreas();

        Area GetArea(int id);
    }
}
