using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class DeliverLoginsManager : IDeliverLoginsManager
    {
        private IDeliverLoginsDB DeliverLoginsDbObject { get; }


        public DeliverLoginsManager(IDeliverLoginsDB deliverLogins)
        {
            DeliverLoginsDbObject = deliverLogins;
        }

        public List<DeliverLogin> GetDeliverLogins()
        {
            return DeliverLoginsDbObject.GetDeliverLogins();
        }

        public int IsUserValid(string email, string password)
        {
            return DeliverLoginsDbObject.IsUserValid(email, password);
        }
    }
}
