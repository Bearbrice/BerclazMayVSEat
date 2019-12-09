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
            //var index = currentDishes.IndexOf(dish);
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

        //NOT USED
        // GET: Dish
        public ActionResult Index()
        {
            return View();
        }

        //NOT USED
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
        
        //NOTUSED
        // GET: Dish/Create
        public ActionResult Create()
        {
            return View();
        }

        //NOTUSED
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

        [HttpPost]
        public ActionResult GetCurrentDishes(DTO.Dish dish)
        {
             return RedirectToAction("Create", "OrdersController");
        }

        // GET: Dish/Delete/5
        public ActionResult Delete(int id)
        {
            //var dish = DishManager.GetDish(id);
            DeleteCurrentDish(id);

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