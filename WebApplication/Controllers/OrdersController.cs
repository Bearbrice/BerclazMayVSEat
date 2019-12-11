using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrdersController : Controller
    {
        private IOrdersManager OrderManager { get; }
        private ICustomerManager CustomerManager { get; }
        public OrdersController(IOrdersManager orderManager, ICustomerManager customerManager)
        {
            OrderManager = orderManager;
            CustomerManager = customerManager;
        }

        // GET: Orders
        public ActionResult Index()
        {
            return View();
        }

        // GET : GetOrderRelativeToStaff
        [HttpGet]
        public ActionResult GetOrdersRelativeToStaff([FromQuery(Name = "username")] string username)
        {
            //var id = HttpContext.Session.Id;

            var name = HttpContext.Session.GetString("user");

            List<OrderStaffCustomer> oscList = new List<OrderStaffCustomer>();

            var orderList = OrderManager.GetOrdersRelativeToStaff(username);

            foreach (var order in orderList)
            {
                oscList.Add(new OrderStaffCustomer
                {
                    idOrder = order.idOrder,
                    status = order.status,
                    scheduled = order.scheduled_at,
                    delivered = order.delivered_at,
                    customerName = CustomerManager.GetCustomer(order.fk_idCustomer).full_name


                });
                
            }

            ViewBag.username = username;
            
            return View(oscList);
        }

        // GET: Orders/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Orders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DTO.Orders order)
        {
            try
            {
                Boolean error = false;

                if(order.scheduled_at < DateTime.Now.AddMinutes(30))
                {
                    error = true;
                }

                if (!(order.scheduled_at.Minute % 15 == 0))
                {
                    error = true;
                }

                if (error == true)
                {
                    return View();
                }
                
               


                    //var x = new DTO.Orders{ status = "ongoing", scheduled_at = DateTime.Now };
                    //OrderManager.AddOrder(x);

                    order.status = "ongoing";
                order=OrderManager.AddOrder(order);

                //retourne tous les ordres du client
                //return RedirectToAction(nameof(GetOrders));
                

                return RedirectToAction("GetOrdersInfo", "Orderdish", new { idOrder = order.idOrder });
            }
            catch
            {
                return View();
            }
        }

        //GET: Orders/Edit
        public ActionResult Edit(int id, string username)
        {
            ViewBag.username = username;

            //Appelle de la méthode/requête SQL update(id) qui changera automatiquement
            //le status en "delivered" et le delivered_at en DateTime.Now
            //La méthode retournera le nouveau GetOrdersRelativeToStaff(username)
            OrderManager.UpdateOrderById(id);

            return RedirectToAction("GetOrdersRelativeToStaff", "Orders", new { username });
        }

        //// POST: Orders/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Orders/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Orders/Delete/5
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