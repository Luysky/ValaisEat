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
    public class OrderDishController : Controller
    {
        private IOrderDishesManager OrderDishManager { get; }
        private IDishesManager DishesManager { get; }
        public OrderDishController(IOrderDishesManager orderdishesManager, IDishesManager dishesManager)
        {
            OrderDishManager = orderdishesManager;
            DishesManager = dishesManager;
        }

      

        // GET: OrderDish
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderDish/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderDish/Create
        public ActionResult Create(int id)
        {         
            return View();
        }

        // POST: OrderDish/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, OrderDish od)
        {

                var creation = new OrderDish();

                creation.IdOrder = (int)HttpContext.Session.GetInt32("idOrder");
                creation.IdDish = id;

            if (od.Quantity > 0  && od.Quantity<=20)
                creation.Quantity = od.Quantity;
            else
            {
                ViewData["Message"] = "La Quantité doit être entre 1 et 20 !";
                return View();
            }
           
                

                var dish = DishesManager.GetDish(id);

                creation.OrderDishPrice = dish.DishPrice * creation.Quantity;

                OrderDishManager.AddOrderDish(creation);

                return RedirectToAction("GetAllDishes", "Dish");
            
        }

        // GET: OrderDish/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDish/Edit/5
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

        // GET: OrderDish/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDish/Delete/5
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

        public IActionResult AffichePanier()
        {
            var panier = OrderDishManager.GetOrderDishes((int)HttpContext.Session.GetInt32("idOrder"));
            List<Panier> total = new List<Panier>();
            foreach (var p in panier)
            {
                Panier article = new Panier();
                var dish = DishesManager.GetDish(p.IdDish);

                article.ProductId = dish.IdDish;
                article.ProductName = dish.Name;
                article.Quantity = p.Quantity;
                article.TotalPrice = p.OrderDishPrice;

                total.Add(article);
            }


           return View(total);
        }

    }
}