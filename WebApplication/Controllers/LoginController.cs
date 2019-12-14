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
        public IActionResult GetAccountDetailByLogin(string username)
        {
            var name = HttpContext.Session.GetString("user");
            ViewBag.username = name;

            AccountDetails accountDetails = new AccountDetails();

            //Test if the connected user is a customer or a staff to display the details of the account
            bool isCustomer = LoginManager.IsItACustomer(username);
            HttpContext.Session.SetString("isCustomer", isCustomer.ToString());
            var isCusto = HttpContext.Session.GetString("isCustomer");
            ViewBag.isCusto = isCusto;

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
            //Get the idCustomer just created to add the fk_idCustomer in the table Login
            Int32.TryParse(HttpContext.Session.GetString("idCustomer"), out int idCustomer);
            l.fk_customerId = idCustomer;

            LoginManager.AddLogin(l);

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