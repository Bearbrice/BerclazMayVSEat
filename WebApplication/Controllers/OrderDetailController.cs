using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderDetailController : Controller
    {
        private OrderDetail od { get; set; }

        // GET: OrderDetail
        public ActionResult Index()
        {
            return View();
        }

        // GET: OrderDetail/Details/5
        public ActionResult Details(int id)
        {
            var odList = od.getDishes();

            return View(odList);
        }

        // GET: OrderDetail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderDetail/Create
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

        // GET: OrderDetail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: OrderDetail/Edit/5
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

        // GET: OrderDetail/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: OrderDetail/Delete/5
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