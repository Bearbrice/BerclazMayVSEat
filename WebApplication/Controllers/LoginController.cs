using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using BLL;
using Microsoft.Extensions.Configuration;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        private ILoginManager LoginManager { get; }
        public LoginController(ILoginManager loginManager)
        {
            LoginManager = loginManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Login l)
        {
            bool isCustomer = LoginManager.IsItACustomer(l.username);
            bool isValid = LoginManager.IsLoginValid(l);
            if (isValid)
            {
                var id = HttpContext.Session.Id;
               HttpContext.Session.SetString("user", l.username);
                //HttpContext.Session.SetString("password", l.password);

                //If this is a customer, the redirection is on GetAllCities (page for customer)
                //If not, this is a staff, so the redirection is on his order
                if (isCustomer)
                {
                    return RedirectToAction("GetAllCities", "City", new { username = l.username });
                }
                else //Staff connection
                {
                    return RedirectToAction("GetOrdersRelativeToStaff", "Orders", new { username = l.username });
                }
            }
            else
            {
                return View();
            }
        }
    }
}