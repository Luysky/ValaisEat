using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IDeliverLoginsDB
    {
        List<DeliverLogin> GetDeliverLogins();
        DeliverLogin GetDeliverLogin(int id);
        int IsUserValid(string email, string password);

    }
}