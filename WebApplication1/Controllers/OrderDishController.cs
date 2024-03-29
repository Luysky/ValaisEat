﻿using System.Collections.Generic;
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
        private IOrdersManager OrderManager { get; }
        public OrderDishController(IOrderDishesManager orderdishesManager, IDishesManager dishesManager, IOrdersManager ordersManager)
        {
            OrderDishManager = orderdishesManager;
            DishesManager = dishesManager;
            OrderManager = ordersManager;
        }

      

        // GET: OrderDish
        public ActionResult Index()
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
         
            int idOrder = (int)HttpContext.Session.GetInt32("idOrder");
    
            var creation = new OrderDish();
                
            creation.IdOrder = idOrder;
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

            var test = OrderDishManager.GetOrderDishes(idOrder);
            if (test != null)
            {
                foreach (var t in test)
                {
                    if (t.IdDish == id)
                    {
                        return RedirectToAction("Update", creation);
                    }
                }
            }
            else
            {
                OrderDishManager.AddOrderDish(creation);

            }



            return RedirectToAction("GetAllDishes", "Dish");


        }

      
        public ActionResult Update(OrderDish orderDish)
        {

            var orderdishDb = OrderDishManager.GetOrderDish(orderDish.IdOrder, orderDish.IdDish);

            if (orderdishDb.Quantity + orderDish.Quantity < 0 || orderdishDb.Quantity + orderDish.Quantity > 20)
            {
                ViewData["Message"] = "La Quantité doit être entre 1 et 20 !";
                return RedirectToAction("Create",orderDish.IdDish);
            }

            orderdishDb.Quantity += orderDish.Quantity;
            orderdishDb.OrderDishPrice += orderDish.OrderDishPrice;

            OrderDishManager.UpdateOrderDish(orderdishDb);

            return RedirectToAction("GetAllDishes", "Dish");

        }

        // GET: OrderDish/Delete/5
        public ActionResult Delete(int idProd, int idOrder)
        {
            OrderDishManager.DeleteOrderDish(idOrder, idProd);
            var prixTotal = OrderManager.GetOrder((int)HttpContext.Session.GetInt32("idOrder"));
            prixTotal.OrderPrice = 0;
            OrderManager.UpdateOrder(prixTotal);
            return RedirectToAction("AffichePanier");
        }

        public IActionResult AffichePanier()
        {
           
            var panier = OrderDishManager.GetOrderDishes((int)HttpContext.Session.GetInt32("idOrder"));

            List<Panier> total = new List<Panier>();

           
            var prixTotal = OrderManager.GetOrder((int)HttpContext.Session.GetInt32("idOrder"));
            if (panier == null)
            {
                return RedirectToAction("GetAllDishes", "Dish");
            }
            foreach (var p in panier)
            {
                Panier article = new Panier();
                var dish = DishesManager.GetDish(p.IdDish);
                article.OrderId = p.IdOrder;
                article.ProductId = p.IdDish;
                article.ProductName = dish.Name;
                article.Quantity = p.Quantity;
                article.TotalPrice = p.OrderDishPrice;

                total.Add(article);

               
                prixTotal.OrderPrice += article.TotalPrice;
               
               
            }

            double prix = (double)prixTotal.OrderPrice;
            OrderManager.UpdateOrder(prixTotal);

            ViewBag.prixTotalCommande = prix;

           return View(total);
        }

        [HttpPost]
        public IActionResult AffichePanier(List<Panier> paniers)
        {

            return RedirectToAction("ValidateOrder", "Order");
        }

        
    }
}