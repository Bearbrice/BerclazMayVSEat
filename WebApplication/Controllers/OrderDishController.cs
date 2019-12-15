using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderDishController : Controller
    {
        private IOrderDishManager OrderDishManager { get; }
        private IDishManager DishManager { get; }
        private IOrdersManager OrderManager { get; }

        public OrderDishController(IOrderDishManager orderDishManager, IDishManager dishManager, IOrdersManager orderManager)
        {
            OrderDishManager = orderDishManager;
            DishManager = dishManager;
            OrderManager = orderManager;
        }

        public void AddOrderDish(int idOrder)
        {
            var dishes = DishController.currentDishes;

            foreach (var dish in dishes)
            {
                DTO.OrderDish od = new DTO.OrderDish { fk_idOrder = idOrder, fk_idDish = dish.idDish };
                OrderDishManager.AddOrderDish(od);
            }

            //Clear all elements in the shopping cart
            DishController.currentDishes.Clear();
        }

        //LIST
        public ActionResult GetOrdersInfo(int idOrder, string type)
        {
            ViewBag.username = HttpContext.Session.GetString("user");

            if (type == "adding")
            {
                //Add data into the SQL OrderDish table
                AddOrderDish(idOrder);
            }

            var orderList = OrderDishManager.GetOrderDishes(idOrder);

            //List based on a model to show specific data to the customer
            List<OrderDishDetails> details = new List<OrderDishDetails>();

            //Get the informations only one time
            var status = OrderManager.GetOrderInfo(idOrder).status;
            var scheduled = OrderManager.GetOrderInfo(idOrder).scheduled_at;

            //Get specific informations such as name and price to sum up the order
            foreach (var orderD in orderList)
            {
                details.Add(new OrderDishDetails
                {
                    idOrder = idOrder,
                    dishName = DishManager.GetDish(orderD.fk_idDish).name,
                    dishPrice = DishManager.GetDish(orderD.fk_idDish).price,
                    scheduled = scheduled,
                    status = status
                });
            }

            return View(details);

        }


    }
}
