using System;
using System.Text;
using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IAreasManager
    {
        List<Area> GetAreas();
        Area GetArea(int id);
    }
}