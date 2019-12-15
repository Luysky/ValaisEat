using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantsManager RestaurantsManager { get; }
        public RestaurantController(IRestaurantsManager restaurantsManager)
        {
            RestaurantsManager = restaurantsManager;
        }
        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Select(int id)
        {
            HttpContext.Session.SetInt32("idRestaurant", id);
            return RedirectToAction("GetAllDishes", "Dish");
        }

        public ActionResult GetAllRestaurants()
        {
            var restaurants = RestaurantsManager.GetRestaurants((int)HttpContext.Session.GetInt32("idCity"));

            return View(restaurants);
        }
    }
}