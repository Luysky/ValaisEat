using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IDeliverLoginsManager
    {
        List<DeliverLogin> GetDeliverLogins();
        int IsUserValid(string email, string password);
    }
}