using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DeliverController : Controller
    {

        private IDeliversManager DeliverManager { get; }
        public DeliverController(IDeliversManager deliversManager)
        {
            DeliverManager = deliversManager;
        }

        // GET: Deliver
        public ActionResult Index()
        {
            return View();
        }

        // GET: Deliver/Details/5
      /*  public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Deliver/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deliver/Create
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

        // GET: Deliver/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Deliver/Edit/5
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

        // GET: Deliver/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

       */
        [HttpGet]
        [ValidateAntiForgeryToken]

        public ActionResult LoginD()
        {

            return View();
        }

        [HttpPost]
        public ActionResult LoginD(Login l)
        {
            var customers = DeliverManager.GetDelivers();
            foreach (var d in customers)
            {
                var test = DeliverManager.IsUserValid(d, l.Email);
                if (test == true)
                {
                    if (d.Password == l.Password)
                    {
                        HttpContext.Session.SetInt32("idDeliver", d.IdDeliver);
                        return RedirectToAction("GetAllAreas", "Areas");
                    }
                }

            }

            return View();



        }
    }
}