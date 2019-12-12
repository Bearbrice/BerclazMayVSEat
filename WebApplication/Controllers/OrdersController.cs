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
        private ICityManager CityManager { get; }
        private IOrderDishManager OrderDishManager { get; }
        private IDishManager DishManager { get; }
        public OrdersController(IDishManager dishmanager, IOrdersManager orderManager, ICustomerManager customerManager, ICityManager cityManager,IOrderDishManager orderDishManager)
        {
            OrderManager = orderManager;
            CustomerManager = customerManager;
            CityManager = cityManager;
            OrderDishManager = orderDishManager;
            DishManager = dishmanager;
        }

        [HttpGet]
        public ActionResult GetOrderDetails(int id)
        {

            var name = HttpContext.Session.GetString("user");

            OrderDetailForStaff odfsOrder = new OrderDetailForStaff();

            var orderDetails = OrderManager.GetOrder(id);

            odfsOrder.idOrder = orderDetails.idOrder;
            odfsOrder.status = orderDetails.status;
            odfsOrder.scheduled = orderDetails.scheduled_at;
            odfsOrder.delivered = orderDetails.delivered_at;
            odfsOrder.customerName = CustomerManager.GetCustomer(orderDetails.fk_idCustomer).full_name;
            odfsOrder.telepone = CustomerManager.GetCustomer(orderDetails.fk_idCustomer).telephone;
            odfsOrder.cityName = CityManager.GetCity(CustomerManager.GetCustomer(orderDetails.fk_idCustomer).fk_idCity).name;
            //Requête SQL ?
            odfsOrder.dishesName.Add(DishManager.GetDish(OrderDishManager.GetOrderDish(orderDetails.idOrder).fk_idDish).name);

            ViewBag.username = name;

            return View(odfsOrder);
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

            List<OrderRelativeToStaffWithCustomer> oscList = new List<OrderRelativeToStaffWithCustomer>();

            var orderList = OrderManager.GetOrdersRelativeToStaff(username);

            foreach (var order in orderList)
            {
                oscList.Add(new OrderRelativeToStaffWithCustomer
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