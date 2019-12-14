using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class CustomersManager : ICustomersManager
    {

        private ICustomersDB CustomersDbObject { get; }

        public CustomersManager(ICustomersDB customersDB)
        {
            CustomersDbObject = customersDB;
        }



        public Customer GetCustomer(int id)
        {
            return CustomersDbObject.GetCustomer(id);
        }
    }

}
