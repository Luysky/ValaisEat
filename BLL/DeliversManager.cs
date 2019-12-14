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
        private IOrdersDB OrdersDbObject { get; }

        public DeliversManager (IDeliversDB deliversDB, IOrdersDB ordersDb)
        {
            DeliversDbObject = deliversDB;
            OrdersDbObject = ordersDb;
        }

        public List<Deliver> GetDelivers(int id)
        {
            return DeliversDbObject.GetDelivers(id);
        }

        public int GetAvailableDeliver(int id)
        {
            int idDeliver = 0;
            int max = 5;

            var all = GetDelivers(id);
            foreach (var a in all)
            {
                if (a.IdDeliver == 0)
                {
                    all.Remove(a);
                }

                var orders = OrdersDbObject.GetOrders(a.IdDeliver);
                if (orders != null)
                {
                    var count = orders.Count;
                    if (count < max)
                    {
                        max = count;
                        idDeliver = a.IdDeliver;
                    }
                }
                else
                    idDeliver = a.IdDeliver;
              

            }

            if (idDeliver == 0)
            {
                foreach (var a in all)
                {
                    if (idDeliver == 0)
                        idDeliver = a.IdDeliver;
                }
            }
           
            return idDeliver;
        }
    }
}
