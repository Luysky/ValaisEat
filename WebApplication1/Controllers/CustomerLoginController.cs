using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class CustomerLoginController : Controller
    {

        private ICustomerLoginsManager CustomerLoginManager { get; }
        public CustomerLoginController(ICustomerLoginsManager customerloginsManager)
        {
            CustomerLoginManager = customerloginsManager;
        }

        // GET: CustomerLogin
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerLogin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerLogin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerLogin/Create
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

        // GET: CustomerLogin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerLogin/Edit/5
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

        // GET: CustomerLogin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerLogin/Delete/5
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

        public ActionResult LoginC()
        {

            ViewData["Message"] = "Veuillez vous identifier";

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


            return View();



        }
    }
}