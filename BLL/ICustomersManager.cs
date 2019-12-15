using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface ICustomersManager
    {
        

        Customer GetCustomer(int id);
        bool CheckCustomer(int idCustomer, string name, string firstname);
    }
}