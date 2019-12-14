using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerManager CustomerManager { get; }
        private ICityManager CityManager { get; }

        public CustomerController(ICustomerManager customerManager, ICityManager cityManager)
        {
            CustomerManager = customerManager;
            CityManager = cityManager;
        }

        // GET: Customer
        public ActionResult Index()
        {

            return View();
        }

        // GET: Customer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Customer/Create
        public ActionResult Create(string errorMessage)
        {
            ViewBag.ErrorCityCode = errorMessage;
            return View();
        }

        // POST: Customer/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Customer c)
        {
            c.fk_idCity = CityManager.GetIdCity(c.fk_idCity);

            if (c.fk_idCity == 0)
            {
                return RedirectToAction("Create", "Customer", new { errorMessage = "City code invalid or not available" });
            }
            else
            {
                if (CustomerManager.AddCustomer(c) == null)
                {
                    return RedirectToAction("Create", "Customer", new { message = "Enter valid values" });
                }
                else
                {
                    return RedirectToAction("Create", "Login", new { c.idCustomer});
                }
                
            }
        }

        // GET: Customer/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Customer/Edit/5
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

        // GET: Customer/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Customer/Delete/5
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