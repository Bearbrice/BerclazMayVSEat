﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BLL;
using WebApplication.Models;
using DTO;

namespace WebApplication.Controllers
{
    public class OrdersController : Controller
    {
        private IOrdersManager OrderManager { get; }
        private ICustomerManager CustomerManager { get; }
        private ICityManager CityManager { get; }
        private IOrderDishManager OrderDishManager { get; }
        private IDishManager DishManager { get; }
        private ILoginManager LoginManager { get; }
        private IRestaurantManager RestaurantManager { get; }
        private IStaffManager StaffManager { get; }

        public OrdersController(IDishManager dishmanager, IOrdersManager orderManager, ICustomerManager customerManager, ICityManager cityManager,IOrderDishManager orderDishManager, ILoginManager loginManager, IStaffManager staffManager, IRestaurantManager restaurantManager, IStaffManager staffM)
        {
            OrderManager = orderManager;
            CustomerManager = customerManager;
            CityManager = cityManager;
            OrderDishManager = orderDishManager;
            DishManager = dishmanager;
            LoginManager = loginManager;
            RestaurantManager = restaurantManager;
            StaffManager = staffM;

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
            //odfsOrder.dishesName.Add(DishManager.GetDish(OrderDishManager.GetOrderDish(orderDetails.idOrder).fk_idDish).name);

            var orderDishList = OrderDishManager.GetOrderDishes(orderDetails.idOrder);

            odfsOrder.dishesName = new List<String>();

            foreach (var od in orderDishList)
            {
                var x = DishManager.GetDish(od.fk_idDish);
                odfsOrder.dishesName.Add(x.name + " ");
            }

            //int cpt = 0;

            //for (int i = 0; i < odfsOrder.dishesName.Count; i++)
            //{
            //    for (int j = 0; j < odfsOrder.dishesName.Count; j++)
            //    {
            //        if (odfsOrder.dishesName.ElementAt(i) == odfsOrder.dishesName.ElementAt(j))
            //        {
            //            cpt++;
            //            odfsOrder.dishesName.Insert(i, odfsOrder.dishesName.ElementAt(i) + cpt);
            //        }
            //    }
            //}

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
            //if (DishController.currentDishes.Count==0)
            //{
            //    ViewBag.ErrorBasketEmpty = "Insert dishes in the shopping cart";
            //    return RedirectToAction("GetCurrentDishes", "Dish");
            //}


            var name = HttpContext.Session.GetString("user");
            ViewBag.username = name;

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

                //Condition 1 : time cannot be lower as current time
                //Condition 2 : give a delay of 30 minutes for current time
                //Remark : The condition 2 include automatically condition 1 no need of two "if"
                if (order.scheduled_at <= DateTime.Now.AddMinutes(30))
                {
                    error = true;
                }

                //Condition : only minutes 00, 15, 30, 45
                if (!(order.scheduled_at.Minute % 15 == 0 || order.scheduled_at.Minute == 00))
                {
                    error = true;
                }

                //string errormessage = "error";
                if (error == true)
                {
                    ViewBag.ErrorMessage = "Error with time given, please correct it";
                    return View();
                }

                //var x = new DTO.Orders{ status = "ongoing", scheduled_at = DateTime.Now };
                //OrderManager.AddOrder(x);

                //assign customer to the order
                var name = HttpContext.Session.GetString("user");

                int id = LoginManager.GetCustomerId(name);

                order.fk_idCustomer = id;

                //assign status
                order.status = "ongoing";

                //add order to DB
                order=OrderManager.AddOrder(order);
                //validate until here

                //assign staff to the order

                var dish = DishController.currentDishes.ElementAt(0);

                var restauId = dish.fk_idRestaurant;

                var y = RestaurantManager.GetRestaurant(restauId);

                List<DTO.Staff> staffs = new List<DTO.Staff>();

                staffs = StaffManager.GetStaffsByCity(y.fk_idCity);

                foreach (var staff in staffs)
                {
                    if (staff.fk_idCity == y.fk_idCity)
                    {
                        order.fk_idStaff = staff.idStaff;
                        break;
                    }
                }

                OrderManager.UpdateOrder(order);

                //retourne tous les ordres du client
                //return RedirectToAction(nameof(GetOrders));

                return RedirectToAction("GetOrdersInfo", "Orderdish", new { idOrder = order.idOrder });
            }
            catch
            {
                ViewBag.ErrorMessage = "Something went wrong, is the format HH:MM correct ? Try again";
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