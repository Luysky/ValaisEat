using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CityController : Controller
    {
        private ICitiesManager CityManager { get; }
        public CityController(ICitiesManager citiesManager)
        {
            CityManager = citiesManager;
        }
        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        // GET: City/Details/5
        public ActionResult Select(int id)
        {
            HttpContext.Session.SetInt32("idRestaurant", id);
            return RedirectToAction("GetAllRestaurants", "Restaurant");
        }

        public ActionResult GetAllCities()
        {
            var cities = CityManager.GetCities();
            //int count = 0;
            

           /* foreach (var c in Tab) {
                if (c.IdArea != HttpContext.Session.GetInt32("idArea"))
                {
                    Tab.RemoveAt(count);
                }
               
                count++;

            }*/

            return View(cities);
        }
    }
}