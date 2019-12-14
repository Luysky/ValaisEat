using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IDeliversDB
    {
        List<Deliver> GetDelivers(int id);
        Deliver GetDeliver(int id);
    }
}
