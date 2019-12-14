using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public interface ICustomerLoginsManager
    { 
        
        int IsUserValid(string email, string password);
    }
}
