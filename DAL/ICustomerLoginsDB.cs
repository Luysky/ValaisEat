using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface ICustomerLoginsDB
    {

        List<CustomerLogin> GetCustomerLogins();

        CustomerLogin GetCustomerLogin(int id);

        int IsUserValid(string email, string password);
    }
}