using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDeliverLoginsManager
    {
        List<DeliverLogin> GetDeliverLogins();
        DeliverLogin GetDeliverLogin(int id);
        int IsUserValid(string email, string password);
    }
}