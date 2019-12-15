using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApplication.Controllers
{
    public class CityController : Controller
    {
        private ICityManager CityManager { get; }
        public CityController(ICityManager cityManager)
        {
            CityManager = cityManager;
        }

        // GET : City
        public ActionResult GetAllCities([FromQuery(Name = "username")] string username)
        {

            ViewBag.username = HttpContext.Session.GetString("user");

            var cityList = CityManager.GetCities();

            //ViewBag.Cities = cityList;
            //ViewBag.Selected = 1;

            return View(cityList);
            //return RedirectToAction("GetRestaurants");


            //var cityList = CityManager.GetCities();
            //return View(cityList);
        } 
    }
}