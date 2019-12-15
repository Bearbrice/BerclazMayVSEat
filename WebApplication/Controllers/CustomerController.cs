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
                CustomerManager.AddCustomer(c);
                HttpContext.Session.SetString("idCustomer", c.idCustomer.ToString());
                return RedirectToAction("Create", "Login", new { c.idCustomer });
            }
        }

    }
}