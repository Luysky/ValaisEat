using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDeliversManager
    {
       

        List<Deliver> GetDelivers();
        Deliver GetDeliver(int id);
    }
}