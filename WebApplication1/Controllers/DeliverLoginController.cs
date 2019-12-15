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
    public class DeliverLoginController : Controller
    {

        private IDeliverLoginsManager DeliverLoginManager { get; }
        public DeliverLoginController(IDeliverLoginsManager deliverloginsManager)
        {
            DeliverLoginManager = deliverloginsManager;
        }

        // GET: DeliverLogin
        public ActionResult Index()
        {
            return View();
        }

          public ActionResult LoginD()
        {

            ViewData["Message"] = "Identify yourself";

            return View();
        }


        [HttpPost]
        public ActionResult LoginD(DeliverLogin log)
        {

            var testConnection = DeliverLoginManager.IsUserValid(log.Email, log.Password);
            if (testConnection != 0)
            {
                HttpContext.Session.SetInt32("idDeliver", testConnection);
                return RedirectToAction("GetAllOrdersDeliver", "Order");
            }
            else
            {
                ViewData["MessageError"] = "Email or Password incorrect, try again";
                return View();
            }
        }
        public ActionResult LogOutD()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}