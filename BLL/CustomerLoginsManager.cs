using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public class CustomerLoginsManager : ICustomerLoginsManager
    {
        private ICustomerLoginsDB CustomerLoginsDbObject { get; }


        public CustomerLoginsManager(ICustomerLoginsDB customerLogins)
        {
            CustomerLoginsDbObject = customerLogins;
        }


        public CustomerLogin GetCustomerLogin(int id)
        {

            return CustomerLoginsDbObject.GetCustomerLogin(id);
        }

        public List<CustomerLogin> GetCustomerLogins()
        {
            return CustomerLoginsDbObject.GetCustomerLogins();

        }

        public int IsUserValid(string email, string password)
        {
            return CustomerLoginsDbObject.IsUserValid(email, password);
        }
    }
}
