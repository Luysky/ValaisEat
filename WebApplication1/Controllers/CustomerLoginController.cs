using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class CustomerLoginController : Controller
    {

        private ICustomerLoginsManager CustomerLoginManager { get; }
        private IOrdersManager OrdersManager { get; }
        private IOrderDishesManager OrderDishesManager { get; }
        public CustomerLoginController(ICustomerLoginsManager customerloginsManager, IOrdersManager ordersManager, IOrderDishesManager orderDishesManager)
        {
            CustomerLoginManager = customerloginsManager;
            OrdersManager = ordersManager;
            OrderDishesManager = orderDishesManager;        }

        // GET: CustomerLogin
        public ActionResult Index()
        {
            return View();
        }
   

        public ActionResult LoginC()
        {

            ViewData["Message"] = "Identify yourself";

            return View();
        }


        [HttpPost]
        public ActionResult LoginC(CustomerLogin log)
        {

            var testConnection = CustomerLoginManager.IsUserValid(log.Email, log.Password);
            if (testConnection != 0)
            {
                HttpContext.Session.SetInt32("idCustomer", testConnection);
                return RedirectToAction("CreateOrder", "Order");
            }
            else
            {
                ViewData["MessageError"] = "Email or Password incorrect, try again";
                return View();
            }
        }

        public ActionResult LogOutC()
        {
            var testOrder = OrdersManager.GetOrder((int)HttpContext.Session.GetInt32("idOrder"));
            if (testOrder.Status == "Order in Progress")
            {
                OrderDishesManager.DeleteOrderDish(testOrder.IdOrder);
                OrdersManager.DeleteOrder(testOrder.IdOrder);
               
            }
            HttpContext.Session.Clear();
            
            return RedirectToAction("Index", "Home"); 
        }
    }
}