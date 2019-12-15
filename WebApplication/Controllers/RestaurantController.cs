using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantManager RestaurantManager { get; }
        public RestaurantController(IRestaurantManager restaurantManager)
        {
            RestaurantManager = restaurantManager;
        }

        // GET : Restaurant/5
        public ActionResult GetRestaurants(int id)
        {
            //to get the user name session on the top right
            ViewBag.username = HttpContext.Session.GetString("user");

            //RestaurantManager rMan = new RestaurantManager(Configuration);
            var restaurantList = RestaurantManager.GetRestaurants(id);

            return View(restaurantList);
        }

    }
}