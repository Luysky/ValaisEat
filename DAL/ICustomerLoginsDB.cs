using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface ICustomerLoginsDB
    {

        List<CustomerLogin> GetCustomerLogins();

        int IsUserValid(string email, string password);
    }
}