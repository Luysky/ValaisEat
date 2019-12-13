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
        private IDishesManager DishManager { get; }
        public DishController(IDishesManager dishesManager)
        {
            DishManager = dishesManager;
        }
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
            
            var dishes = DishManager.GetDishes((int)HttpContext.Session.GetInt32("idRestaurant"));


            return View(dishes);
        }

        public IActionResult AjoutPanier(int id)
        {
            
            return RedirectToAction("Create", "OrderDish", new { id });
        }

       


    }
}