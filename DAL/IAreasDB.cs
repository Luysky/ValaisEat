using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
   public interface IAreasDB
    {
        List<Area> GetAreas();

        Area GetArea(int id);
    }
}
