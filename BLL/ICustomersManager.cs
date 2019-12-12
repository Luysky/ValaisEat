using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface ICustomersManager
    {
        

        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        Customer AddCustomer(Customer customer);
        int UpdateCustomer(Customer customer);
        int DeleteCustomer(int id);

    }
}