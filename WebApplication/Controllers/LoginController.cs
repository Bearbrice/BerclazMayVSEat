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
        private IStaffManager StaffManager { get; }
        public LoginController(ILoginManager loginManager, ICustomerManager customerManager, IStaffManager staffManager)
        {
            LoginManager = loginManager;
            CustomerManager = customerManager;
            StaffManager = staffManager;
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
        public ActionResult Create(int idCustomer)
        {
            HttpContext.Session.SetString("idCustomer", idCustomer.ToString());
            ViewBag.idCustomer = idCustomer;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Login l)
        {
            Int32.TryParse(HttpContext.Session.GetString("idCustomer"), out int idCustomer);

            LoginManager.AddLogin(l, idCustomer);

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Index(Login l)
        {
            //Test if the user entered something in the field username
            if (l.username == null)
            {
                ViewBag.ErrorMessage = "*enter a username*";
                return View();
            }
            //Test if the user entered something in the field password
            if (l.password == null)
            {
                ViewBag.ErrorMessage = "*enter a password*";
                return View();
            }

            bool isCustomer = LoginManager.IsItACustomer(l.username);
            bool isValid = LoginManager.IsLoginValid(l);
            if (isValid)
            {
                HttpContext.Session.SetString("user", l.username);

                //If this is a customer, the redirection is on GetAllCities (page for customer)
                //If not, this is a staff, so the redirection is on the orders he must manage
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
                ViewBag.ErrorMessage = "*invalid login*";
                return View();
            }
        }
    }
}