using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class DishController : Controller
    {
        // GET: Dish
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dish/Details/5
        public ActionResult Add(int id)
        {
            return View();
        }

        public ActionResult GetAllDishes()
        {
            var dishes = DishesManager.GetDishes();

            /* int count = 0;

             foreach (var r in restaurants)
             {
                 if (r.IdCity != HttpContext.Session.GetInt32("idCity"))
                 {
                     restaurants.RemoveAt(count);
                 }

                 count++;
             }*/

            return View(dishes);
        }

    }
}