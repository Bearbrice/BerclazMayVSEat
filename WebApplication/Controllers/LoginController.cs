using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DTO;
using BLL;
using Microsoft.Extensions.Configuration;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class LoginController : Controller
    {
        private ILoginManager LoginManager { get; }
        private ICustomerManager CustomerManager { get; }
        public LoginController(ILoginManager loginManager, ICustomerManager customerManager)
        {
            LoginManager = loginManager;
            CustomerManager = customerManager;
        }

        [HttpGet]
        public IActionResult GetCustomerByLogin(string username)
        {
            var name = HttpContext.Session.GetString("user");

            //PAS FORCEMENT UN CUSTOMER !!!!

            CustomerDetailsRelativeToLogin cdrtlDetails = new CustomerDetailsRelativeToLogin();

            //faire une requête SQL qui get le login par rapport au username
            //var customerDetails = CustomerManager.GetCustomer(LoginManager.GetLogin(username).fk_customerId);

            //cdrtlDetails.fullName = customerDetails.full_name;

            ViewBag.username = name;

            return View();
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
            //Test if the user entered something in the field username
            if (l.username == null)
            {
                ViewBag.ErrorMessageUsername = "Enter a username";
                return View();
            }
            //Test if the user entered something in the field password
            if (l.password == null)
            {
                ViewBag.ErrorMessagePassword = "Enter a password";
                return View();
            }

            bool isCustomer = LoginManager.IsItACustomer(l.username);
            bool isValid = LoginManager.IsLoginValid(l);
            if (isValid)
            {
                //var id = HttpContext.Session.Id;
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