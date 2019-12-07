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

        // GET: City
        public ActionResult Index()
        {
            return View();
        }

        // GET : City
        public ActionResult GetCities()
        {
           
            var cityList = new SelectList(CityManager.GetCities());

            ViewBag.Cities = cityList;
            //ViewBag.Selected = 1;

            return View();
            //return RedirectToAction("GetRestaurants");


            //var cityList = CityManager.GetCities();
            //return View(cityList);
        }

        // GET : City
        public ActionResult GetAllCities([FromQuery(Name = "username")] string username)
        {

            var name = HttpContext.Session.GetString("username");
            var cityList = CityManager.GetCities();
            ViewBag.username = username;

            //ViewBag.Cities = cityList;
            //ViewBag.Selected = 1;

            return View(cityList);
            //return RedirectToAction("GetRestaurants");


            //var cityList = CityManager.GetCities();
            //return View(cityList);
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
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

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: City/Edit/5
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

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: City/Delete/5
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