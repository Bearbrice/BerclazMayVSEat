using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using DTO;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class DishController : Controller
    {
        private IDishManager DishManager { get; }

        public DishController(IDishManager dishManager)
        {
            DishManager = dishManager;
        }

        public static List<DTO.Dish> currentDishes = new List<DTO.Dish>();

        public List<DTO.Dish> GetAllDishes()
        {
            return currentDishes;
        }

        public void AddCurrentDish(DTO.Dish dish)
        {
            currentDishes.Add(dish);
        }

        public void DeleteCurrentDish(int idx)
        {
            //var index = currentDishes.IndexOf(dish);

            


            currentDishes.RemoveAt(idx);
        }

        // GET: Dish
        public ActionResult Index()
        {
            return View();
        }

        // GET: Dish/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Dish/GetDishes/5
        public ActionResult GetDishes(int id)
        {
            //RestaurantManager rMan = new RestaurantManager(Configuration);
            var dishList = DishManager.GetDishes(id);

            return View(dishList);
        }
        

        // GET: Dish/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dish/Create
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

        


        // GET: Dish/Edit/5
        public ActionResult Edit(int id)
        {
            var dish = DishManager.GetDish(id);

            return View(dish);
        }

        // POST: Dish/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(DTO.Dish dish)
        {
            //try
            // {
            // TODO: Add update logic here
            //od.dishes.Add(dish);

            //currentDishes.Add(dish);
            AddCurrentDish(dish);
            //currentDishes.Add(new DTO.Dish {idDish=dish.idDish, name=dish.name, price=dish.price, fk_idRestaurant=dish.fk_idRestaurant });
                //OrderDetail.Add(dish);
                //OrderDetail.GetDishes();

                //return RedirectToAction(nameof(GetDishes));
                return View();
           // }
           // catch
           // {
            //    return View();
            //}
        }

        // GET: Dish/GetDishes/5
        public ActionResult GetCurrentDishes()
        {
            //RestaurantManager rMan = new RestaurantManager(Configuration);
            var dishList = GetAllDishes();

            return View(dishList);
        }

        // GET: Dish/Delete/5
        public ActionResult Delete(int idx)
        {
            //var dish = DishManager.GetDish(id);
            DeleteCurrentDish(idx);

            return RedirectToAction(nameof(GetCurrentDishes));
        }

        //POST: Dish/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
               
                return RedirectToAction(nameof(GetCurrentDishes));
            }
            catch
            {
                return View();
            }
        }
    }
}