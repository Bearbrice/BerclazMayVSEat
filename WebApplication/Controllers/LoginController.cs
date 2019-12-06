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
            bool isValid = LoginManager.IsLoginValid(l);
            if (isValid)
            {
                HttpContext.Session.SetString("username", l.username);
                return RedirectToAction("GetAllCities", "City", new { isValid = isValid, user = "test" });
            }
            else
            {
                return View();
            }
        }
    }
}