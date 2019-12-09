using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{

    // mettre la class en public
    // créer un private Ixxx
    // A supprimer dans IAreas  le Icities truc


    public class AreasManager : IAreasManager
    {


        private IAreasDB AreasDbObject { get; }

        
        public AreasManager (IAreasDB areasDB)
        {
            AreasDbObject = areasDB;
        }

        
        public Area GetArea(int id)
        {
        
            return AreasDbObject.GetArea(id);
        }

        public List<Area> GetAreas()
        {
            return AreasDbObject.GetAreas();
            
        }
    }
}
