using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;

namespace WebApplication.Controllers
{
    public class OrdersController : Controller
    {
        private IOrdersManager OrderManager { get; }
        public OrdersController(IOrdersManager orderManager)
        {
            OrderManager = orderManager;
        }

        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        // GET : GetOrderRelativeToStaff
        public ActionResult GetOrdersRelativeToStaff([FromQuery(Name = "username")] string username)
        {
            var name = HttpContext.Session.GetString("user");
            var orderList = OrderManager.GetOrdersRelativeToStaff(username);
            ViewBag.username = username;

            return View(orderList);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
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

        //GET: Orders/Edit/5
        public ActionResult Edit(int id, string username)
        {
            var order = OrderManager.GetOrder(id);
            ViewBag.username = username;
            return View(order);
        }

        [HttpPost]
        public ActionResult Edit(DTO.Orders o)
        {
            string username = HttpContext.Session.GetString("username");
            username = "michmich";
            ViewBag.username = username;
            OrderManager.UpdateOrder(o);
            return RedirectToAction("GetOrdersRelativeToStaff", "Orders", new { username });
            //return RedirectToAction(nameof(GetOrdersRelativeToStaff));
        }

        //// POST: Orders/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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