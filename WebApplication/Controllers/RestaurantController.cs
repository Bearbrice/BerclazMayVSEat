using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Microsoft.Extensions.Configuration;

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

        // GET: Restaurant/Details/5
        public ActionResult Details(int id)
        {
            //RestaurantManager rMan = new RestaurantManager(Configuration);
            var restaurant = RestaurantManager.GetRestaurant(id);
            return View(restaurant);
        }
    }
}