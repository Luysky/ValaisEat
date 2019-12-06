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

        // GET: Area/Details/5
        public ActionResult Select(int id)
        {
            return View();
        }

        public ActionResult GetAllAreas() {

            var areas = AreaManager.GetAreas();

            return View(areas);
        }

    }
}