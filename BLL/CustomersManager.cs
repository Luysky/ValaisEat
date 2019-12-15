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

        public bool CheckCustomer(int idCustomer, string name, string firstname)
        {
            var customer = GetCustomer(idCustomer);

            if (customer.Name == name && customer.Firstname == firstname)
                return true;
            else
                return false;

        }
    }

}
