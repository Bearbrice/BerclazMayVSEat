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

        [HttpPost]
        public IActionResult Index(Login l)
        {
            bool isCustomer = LoginManager.IsItACustomer(l.username);
            bool isValid = LoginManager.IsLoginValid(l);
            if (isValid)
            {
                HttpContext.Session.SetString("username", l.username);
                HttpContext.Session.SetString("password", l.password);

                //If this is a customer, the redirection is on GetAllCities (page for customer)
                //If not, this is a staff, so the redirection is on his order
                if (isCustomer)
                {
                    return RedirectToAction("GetAllCities", "City", new { isValid = isValid, user = l.username });
                }
                else
                {
                    return RedirectToAction("Create", "City", new { isValid = isValid, user = l.username });
                }

            }
            else
            {
                return View();
            }
        }
    }
}