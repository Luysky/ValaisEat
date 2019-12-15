using System.Collections.Generic;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderController : Controller
    {

        private IOrdersManager OrderManager { get; }
        private ICitiesManager CitiesManager { get; }
        private ICustomersManager CustomerManager { get; }
        private IDeliversManager DeliverManager { get; }
        public OrderController(IOrdersManager ordersManager, ICitiesManager citiesManager, ICustomersManager customersManager, IDeliversManager deliversManager)
        {
            OrderManager = ordersManager;
            CitiesManager = citiesManager;
            CustomerManager = customersManager;
            DeliverManager = deliversManager;
        }

        
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Archive(int id)
        {
            var order = OrderManager.GetOrder(id);
            order.Status = "Delivered";
            OrderManager.UpdateOrder(order);

            return RedirectToAction("GetAllOrdersDeliver");
        }
        // GET: Order/Create
        public ActionResult CreateOrder()
        {
            var newOrder = new Order();
            newOrder.IdCustomer = (int)HttpContext.Session.GetInt32("idCustomer");
            newOrder.IdDeliver = 0;
            newOrder.OrderPrice = 0 ;
            newOrder.Status = "Order in Progress";

            var creation = OrderManager.AddOrder(newOrder);

            HttpContext.Session.SetInt32("idOrder", creation.IdOrder);

            return RedirectToAction("GetAllCities", "City");
        }

   
        public ActionResult ValidateOrder()
        {
            var order = OrderManager.GetOrder((int)HttpContext.Session.GetInt32("idOrder"));
            order.IdDeliver = DeliverManager.GetAvailableDeliver((int)HttpContext.Session.GetInt32("idCity"));
            order.Status = "Deliver in Progress";

            OrderManager.UpdateOrder(order);
            int count = 1;
            var orders = OrderManager.GetOrders(order.IdDeliver);
            foreach (var o in orders)
            {
                if (o.IdOrder == order.IdOrder)
                {
                    ViewBag.deliverTime = 10 * count;
                }
                else
                {
                    count++;
                }
            }
            ViewBag.IdOrder = order.IdOrder;
           

            return View();
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id, string name, string firstname)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public ActionResult GetAllOrdersDeliver()
        {
            List<OrderDetails> results = null;
            var orders = OrderManager.GetOrders((int)HttpContext.Session.GetInt32("idDeliver"));
            foreach (var o in orders)
            {
                if (results == null)
                    results = new List<OrderDetails>();

               
                var Details = new OrderDetails();

                Details.IdOrder = o.IdOrder;
                Details.Status = o.Status;
                Details.Price = o.OrderPrice;

                var customer = CustomerManager.GetCustomer(o.IdCustomer);

                Details.CustomerName = customer.Name + customer.Firstname;
                Details.CustumerAdress = customer.Adress;

                var city = CitiesManager.GetCity(customer.IdCity);

                Details.Npa = city.Npa;
                Details.City = city.Name;

               
                results.Add(Details);
                
                
            }


            return View(results);
        }

    }
}