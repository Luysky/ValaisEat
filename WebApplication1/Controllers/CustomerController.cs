using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomersManager CustomerManager { get; }
        public CustomerController(ICustomersManager customersManager)
        {
            CustomerManager = customersManager;
        }

        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customer/Create
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

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        public ActionResult LoginC() {

            return View();
        }

        [HttpGet]
        public ActionResult LoginC(string email, string password)
        {
            var customers = CustomerManager.GetCustomers();
            foreach (var c in customers)
            {
                var test = CustomerManager.IsUserValid(c, email);
                if (test == true)
                {
                    if (c.Password == password)
                    {
                        HttpContext.Session.SetInt32("idCustomer", c.IdCustomer);
                        return RedirectToAction("GetAllAreas", "Areas");
                    }
                }
               
            }

            return View();
            


        }


    }
}