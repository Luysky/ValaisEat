using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    class DeliversManager : IDeliversManager
    {
        public IDeliversDB DeliversDbObject => throw new NotImplementedException();

        public Deliver GetDeliver(int id)
        {
            throw new NotImplementedException();
        }

        public List<Deliver> GetDelivers()
        {
            throw new NotImplementedException();
        }
    }
}
