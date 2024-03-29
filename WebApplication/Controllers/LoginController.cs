﻿using BLL;
using DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
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
        public IActionResult GetAccountDetailByLogin(string username)
        {
            ViewBag.username = HttpContext.Session.GetString("user");

            AccountDetails accountDetails = new AccountDetails();

            //Test if the connected user is a customer or a staff to display the details of the account relative to it
            bool isCustomer = LoginManager.IsItACustomer(username);
            HttpContext.Session.SetString("isCustomer", isCustomer.ToString());
            ViewBag.isCusto = HttpContext.Session.GetString("isCustomer");

            if (isCustomer)
            {
                var orderDetails = CustomerManager.GetCustomer(LoginManager.GetCustomerId(username));

                accountDetails.fullName = orderDetails.full_name;
                accountDetails.username = username;
                accountDetails.createdOrHired = orderDetails.created_at;
                accountDetails.phone = orderDetails.telephone;

                return View(accountDetails);
            }
            else
            {
                var orderDetails = StaffManager.GetStaff(LoginManager.GetStaffId(username));

                accountDetails.fullName = orderDetails.full_name;
                accountDetails.username = username;
                accountDetails.createdOrHired = orderDetails.hired_on;
                accountDetails.phone = orderDetails.telephone;

                return View(accountDetails);
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create(int idCustomer, string errorMessage)
        {
            ViewBag.ErrorUsernameTaken = errorMessage;
            HttpContext.Session.SetString("idCustomer", idCustomer.ToString());
            ViewBag.idCustomer = idCustomer;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Login l)
        {
            //Get the idCustomer just created to add the fk_idCustomer in the table Login
            Int32.TryParse(HttpContext.Session.GetString("idCustomer"), out int idCustomer);
            l.fk_customerId = idCustomer;

            //Manage the exception if the new user enter a username already taken or valide values !
            if (LoginManager.IsUsernameTaken(l.username))
            {
                return RedirectToAction("Create", "Login", new { idCustomer, errorMessage = "Username '" + l.username + "' is already taken." });
            }
            else
            {
                if (LoginManager.AddLogin(l) == null)
                {
                    return RedirectToAction("Create", "Login", new { idCustomer, errorMessage = "Enter valid values" });
                }
                else
                {
                    return RedirectToAction("Index", "Login");
                }
            }
        }

        [HttpPost]
        public IActionResult Index(Login l)
        {
            bool isCustomer = LoginManager.IsItACustomer(l.username);
            bool isValid = LoginManager.IsLoginValid(l);
            if (isValid)
            {
                HttpContext.Session.SetString("user", l.username);

                //If this is a customer, the redirection is on GetAllCities (page for customer)
                //If not, this is a staff, so the redirection is on the orders he must manage
                if (isCustomer)
                {
                    HttpContext.Session.SetString("isCustomer", isCustomer.ToString());
                    ViewBag.isCusto = isCustomer.ToString();
                    return RedirectToAction("GetAllCities", "City", new { username = l.username });
                }
                else //Staff connection
                {
                    HttpContext.Session.SetString("isCustomer", isCustomer.ToString());
                    ViewBag.isCusto = isCustomer.ToString();
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