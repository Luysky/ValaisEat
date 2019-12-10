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
        private IDishesManager DishesManager { get; }
        public DishController(IDishesManager dishesManager)
        {
            DishesManager = dishesManager;
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
            
            var dishes = DishesManager.GetDishes();


            return View(dishes);
        }


    }
}