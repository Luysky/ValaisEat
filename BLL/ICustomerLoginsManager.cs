using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICustomerLoginsManager
    { 
        List<CustomerLogin> GetCustomerLogins();

        CustomerLogin GetCustomerLogin(int id);

        int IsUserValid(string email, string password);
    }
}
