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
        //private IConfiguration Configuration { get; }
        //public RestaurantController(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        private IRestaurantManager RestaurantManager { get; }
        public RestaurantController(IRestaurantManager restaurantManager)
        {
            RestaurantManager = restaurantManager;
        }

        // GET: Restaurant
        public ActionResult Index()
        {
            return View();
        }

        // GET : Restaurant/5
        public ActionResult GetRestaurants(int id)
        {
            //to get the user name session on the top right
            var name = HttpContext.Session.GetString("user");
            ViewBag.username = name;

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

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
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

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
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

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurant/Delete/5
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
    }
}