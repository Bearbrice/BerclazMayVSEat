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
        private IOrdersManager OrderManager { get; }


        public OrderDishController(IOrderDishManager orderDishManager, IDishManager dishManager, IOrdersManager orderManager)
        {
            OrderDishManager = orderDishManager;
            DishManager = dishManager;
            OrderManager = orderManager;
        }

        public void AddOrderDish(int idOrder)
        {
            var dishes = DishController.currentDishes;

            foreach (var dish in dishes)
            {
                DTO.OrderDish od = new DTO.OrderDish { fk_idOrder = idOrder, fk_idDish = dish.idDish };
                OrderDishManager.AddOrderDish(od);
            }

            //return RedirectToAction("GetOrdersInfo", "OrderDishController", new { @id = idOrder });
        }

        //LIST
        public ActionResult GetOrdersInfo(int idOrder, string type)
        {
            if (type == "adding")
            {
                //Add data into the SQL OrderDish table
                AddOrderDish(idOrder);
            }

            //List<DTO.OrderDish> orderDishes;
            //orderDishes = OrderDishManager.GetOrderDishes();
            var orderList = OrderDishManager.GetOrderDishes(idOrder);

            //List based on a model to show specific data to the customer
            List<OrderDishDetails> details = new List<OrderDishDetails>();

            //Get the informations only one time
            var status = OrderManager.GetOrderInfo(idOrder).status;
            var scheduled = OrderManager.GetOrderInfo(idOrder).scheduled_at;

            //Get specific informations such as name and price to sum up the order
            foreach (var orderD in orderList)
            {
                details.Add(new OrderDishDetails
                {
                    idOrder = idOrder,
                    dishName = DishManager.GetDish(orderD.fk_idDish).name,
                    dishPrice = DishManager.GetDish(orderD.fk_idDish).price,
                    scheduled = scheduled,
                    status = status
                }) ;
            }

            return View(details);

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
