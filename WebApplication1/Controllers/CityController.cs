using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class CityController : Controller
    {
        private ICitiesManager CityManager { get; }
        public CityController(ICitiesManager citiesManager)
        {
            CityManager = citiesManager;
        }
        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        // GET: City/Details/5
        public ActionResult Select(int id)
        {
            HttpContext.Session.SetInt32("idCity", id);
            return RedirectToAction("GetAllRestaurants", "Restaurant");
        }

        public ActionResult GetAllCities()
        {
            var cities = CityManager.GetCities();

            return View(cities);
        }
    }
}