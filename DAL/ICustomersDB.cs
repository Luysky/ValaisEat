using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface ICustomersDB
    {
        
        Customer GetCustomer(int id);
      

    }
}
