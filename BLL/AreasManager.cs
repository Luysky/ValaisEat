using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    class AreasManager : IAreasManager
    {
        public IAreasDB AreasDbObject => throw new NotImplementedException();

        public Area GetArea(int id)
        {
            throw new NotImplementedException();
        }

        public List<Area> GetAreas()
        {
            throw new NotImplementedException();
        }
    }
}
