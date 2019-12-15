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
        private IOrdersManager OrdersManager { get; }

        public DishController(IDishManager dishManager, IOrdersManager orderManager)
        {
            DishManager = dishManager;
            OrdersManager = orderManager;
        }

        //Static list
        public static List<DTO.Dish> currentDishes = new List<DTO.Dish>();

        //Method GET for the static list
        public List<DTO.Dish> GetAllDishes()
        {
            return currentDishes;
        }

        //Method ADD for the static list
        public void AddCurrentDish(DTO.Dish dish)
        {
            currentDishes.Add(dish);
        }

        //Method DELETE for the static list
        public void DeleteCurrentDish(int id)
        {
            int count = -1;
            foreach (var item in currentDishes)
            {
                count++;
                if (item.idDish == id)
                {
                    break;
                }
                
            };

            currentDishes.RemoveAt(count);
        }

        // GET: Dish/GetDishes/5
        public ActionResult GetDishes(int id)
        {
            //to get the user name session on the top right
            ViewBag.username = HttpContext.Session.GetString("user");

            var dishList = DishManager.GetDishes(id);

            return View(dishList);
        }

        // GET: Dish/Edit/5
        public ActionResult Edit(int id)
        {
            //to get the user name session on the top right
            ViewBag.username = HttpContext.Session.GetString("user");

            var dish = DishManager.GetDish(id);

            return View(dish);
        }

        // POST: Dish/Edit/5
        [HttpPost]
        public ActionResult Edit(DTO.Dish dish)
        {
            AddCurrentDish(dish);

            return RedirectToAction("GetDishes", "Dish", new { id=dish.fk_idRestaurant });
        }

        // GET: Dish/GetDishes/5
        public ActionResult GetCurrentDishes()
        {
            ViewBag.username = HttpContext.Session.GetString("user");
            
            var dishList = GetAllDishes();

            return View(dishList);
        }

       

        // Not a view
        public ActionResult Delete(int id)
        {
            DeleteCurrentDish(id);

            return RedirectToAction(nameof(GetCurrentDishes));
        }

        //POST, redirect to GetCurrentDishes
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {               
                return RedirectToAction(nameof(GetCurrentDishes));
            }
            catch
            {
                return View();
            }
        }
    }
}