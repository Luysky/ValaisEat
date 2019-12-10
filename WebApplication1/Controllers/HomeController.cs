using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private ICustomersManager CustomerManager { get; }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Customers(Login l)
        {
            /*
            ViewData["Message"] = "Veuillez vous identifier";

            return View();
            */


            //C'est GetCustomers qui a un problème. C'est vide ou je sais pas quoi. 
            var customers = CustomerManager.GetCustomers();
            foreach (var c in customers)
            {
                var test = CustomerManager.IsUserValid(c, l.Username);
                if (test == true)
                {
                    if (c.Password == l.Password)
                    {
                        HttpContext.Session.SetInt32("idCustomer", c.IdCustomer);
                        return RedirectToAction("GetAllAreas", "Areas");
                    }
                }

            }


            return View();


        }

        public IActionResult Delivers()
        {
            ViewData["Message"] = "Veuillez vous identifier";

            return View();

        }


     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
