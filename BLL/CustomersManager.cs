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

        public CustomersManager (ICustomersDB customersDB)
        {
            CustomersDbObject = customersDB;
        }
            

        public Customer AddCustomer(Customer customer)
        {
           return CustomersDbObject.AddCustomer(customer);
        }


        public Customer GetCustomer(int id)
        {
            return CustomersDbObject.GetCustomer(id);
        }

        public List<Customer> GetCustomers()
        {
            return CustomersDbObject.GetCustomers();
        }

        public int UpdateCustomer(Customer customer)
        {
            return CustomersDbObject.UpdateCustomer(customer);
        }
    }
}
