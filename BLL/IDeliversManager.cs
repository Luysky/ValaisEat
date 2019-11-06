using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    internal interface IDeliversManager
    {
        IDeliversDB DeliversDbObject { get; }

        List<Deliver> GetDelivers();
        Deliver GetDeliver(int id);
    }
}