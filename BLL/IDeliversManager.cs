using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDeliversManager
    {
       

        List<Deliver> GetDelivers(int id);
        Deliver GetDeliver(int id);

        int GetAvailableDeliver(int id);
    }
}