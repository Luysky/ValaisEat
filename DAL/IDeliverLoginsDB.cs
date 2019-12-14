using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IDeliverLoginsDB
    {
        List<DeliverLogin> GetDeliverLogins();
        int IsUserValid(string email, string password);

    }
}