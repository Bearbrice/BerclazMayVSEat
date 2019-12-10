using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderDishController : Controller
    {

        private IOrderDishManager OrderDishManager { get; }
        private IDishManager DishManager { get; }

        public OrderDishController(IOrderDishManager orderDishManager, IDishManager dishManager)
        {
            OrderDishManager = orderDishManager;
            DishManager = dishManager;
        }

        public ActionResult AddOrderDish(int idOrder)
        {
            var dishes = DishController.currentDishes;

            foreach(var dish in dishes)
            {
                DTO.OrderDish od = new DTO.OrderDish { fk_idOrder = idOrder, fk_idDish=dish.idDish };
                OrderDishManager.AddOrderDish(od);
            }

            return RedirectToAction(nameof(GetOrdersInfo));
        }

        //LIST
        public ActionResult GetOrdersInfo(int idOrder)
        {
            var orderList = OrderDishManager.GetOrderDishes();

            List<OrderDishDetails> details = new List<OrderDishDetails>();
            
            foreach(var orderD in orderList)
            {
                details.Add(new OrderDishDetails
                {
                    idOrder = idOrder,
                    //dishName = DishManager.GetDish()
                    //dishName=

                });
                
            }
            


            //ViewBag.Cities = cityList;
            //ViewBag.Selected = 1;

            return View(details);
            //return RedirectToAction("GetRestaurants");


            //var cityList = CityManager.GetCities();
            //return View(cityList);
        }

        // GET: OrderDish
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderDish/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OrderDish/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDish/Create
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

        // GET: OrderDish/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDish/Edit/5
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

        // GET: OrderDish/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDish/Delete/5
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