using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderController : Controller
    {

        private IOrdersManager OrderManager { get; }
        public OrderController(IOrdersManager ordersManager)
        {
            OrderManager = ordersManager;
        }


        private ICitiesManager CitiesManager { get; }



        private ICustomersManager CustomerManager { get; }
      

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
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
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
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
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
        }

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