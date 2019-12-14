using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult CreateOrder()
        {
            var newOrder = new Order();
            newOrder.IdCustomer = (int)HttpContext.Session.GetInt32("idCustomer");
            newOrder.IdDeliver = 0;
            newOrder.OrderPrice = 0 ;
            newOrder.Status = "En cours de Commande";

            var creation = OrderManager.AddOrder(newOrder);

            HttpContext.Session.SetInt32("idOrder", creation.IdOrder);

            return RedirectToAction("GetAllCities", "City");
        }

        // POST: Order/Create
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Order/Edit/5
        public ActionResult ValidateOrder()
        {
            var order = OrderManager.GetOrder((int)HttpContext.Session.GetInt32("idOrder"));
            order.IdDeliver = DeliverManager.GetAvailableDeliver((int)HttpContext.Session.GetInt32("idCity"));
            order.Status = "En cours de Livraison";

            OrderManager.UpdateOrder(order);

            return View();
        }

        // POST: Order/Edit/5
        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }*/

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
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

                Details.CustomerName = customer.Name;
                Details.CustumerAdress = customer.Adresse;

                var city = CitiesManager.GetCity(customer.IdCity);

                Details.Npa = city.Npa;
                Details.City = city.Name;

               
                results.Add(Details);
                
                
            }


            return View(results);
        }

    }
}