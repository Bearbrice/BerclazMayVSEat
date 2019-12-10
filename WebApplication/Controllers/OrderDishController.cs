using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class OrderDishController : Controller
    {
        private IOrderDishManager OrderDishManager { get; }
        //private IDishManager DishManager { get; }
       // private IOrdersManager OrderManager { get; }


        public OrderDishController(IOrderDishManager orderDishManager)
       {
            OrderDishManager = orderDishManager;
            //DishManager = dishManager;
            //OrderManager = orderManager;
       }

        public void AddOrderDish(int idOrder)
        {
            var dishes = DishController.currentDishes;

            foreach (var dish in dishes)
            {
                DTO.OrderDish od = new DTO.OrderDish { fk_idOrder = idOrder, fk_idDish = dish.idDish };
                //OrderDishManager.AddOrderDish(od);
            }

            //return RedirectToAction("GetOrdersInfo", "OrderDishController", new { @id = idOrder });
        }

        //LIST
        public ActionResult GetOrdersInfo(int idOrder)
        {
            //AddOrderDish(idOrder);


           // var orderList = OrderDishManager.GetOrderDishes();

            //List<OrderDishDetails> details = new List<OrderDishDetails>();

            //foreach (var orderD in orderList)
            //{
            //    details.Add(new OrderDishDetails
            //    {
            //        idOrder = idOrder,
            //        //dishName = DishManager.GetDish(orderD.fk_idDish).name,
            //        //dishPrice = DishManager.GetDish(orderD.fk_idDish).price,
            //        //scheduled = OrderManager.GetOrder(idOrder).scheduled_at
            //    });
            //}

            return View();

        }

 
    }
}