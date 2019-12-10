using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class DeliversManager : IDeliversManager
    {

        private IDeliversDB DeliversDbObject { get; }

        public DeliversManager (IDeliversDB deliversDB)
        {
            DeliversDbObject = deliversDB;
        }

        public Deliver GetDeliver(int id)
        {
            return DeliversDbObject.GetDeliver(id);
        }

        public List<Deliver> GetDelivers()
        {
            return DeliversDbObject.GetDelivers();
        }

        public bool IsUserValid(Deliver d, string email)
        {
            return DeliversDbObject.IsUserValid(d,email);
        }
    }
}
