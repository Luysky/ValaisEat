using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebApplication1.Controllers
{
    public class AreaController : Controller
    {

        private IAreasManager AreaManager { get; }
        public AreaController(IAreasManager areasManager)
        {
            AreaManager = areasManager;
        }

      
        // GET: Area
        public ActionResult Index()
        {
            return View();
        }

        // GET: Area/Select/5
        public ActionResult Select(int id)
        {
            HttpContext.Session.SetInt32("idArea", id);
            return RedirectToAction("GetAllCities", "City");
        }

        public ActionResult GetAllAreas() {

            var areas = AreaManager.GetAreas();

            return View(areas);
        }

    }
}