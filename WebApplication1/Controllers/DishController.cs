﻿using System;
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
   
        public ActionResult Index()
        {
            return View();
        }

    
        public ActionResult GetAllDishes()
        {
            
            var dishes = DishManager.GetDishes((int)HttpContext.Session.GetInt32("idRestaurant"));

            if(dishes==null)
            {
                return RedirectToAction("GetAllRestaurants", "Restaurant");
            }

            return View(dishes);
        }

        public IActionResult AjoutPanier(int id)
        {
            
            return RedirectToAction("Create", "OrderDish", new { id });
        }

       


    }
}