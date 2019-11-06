using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    class CustomersManager : ICustomersManager
    {
        public ICustomersDB CustomersDbObject => throw new NotImplementedException();

        public Customer AddCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }

        public int DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public Customer GetCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public List<Customer> GetCustomers()
        {
            throw new NotImplementedException();
        }

        public int UpdateCustomer(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
