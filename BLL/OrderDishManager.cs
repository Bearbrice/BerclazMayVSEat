using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class OrderDishManager : IOrderDishManager
    {
        private IOrderDishDB OrderdishDBObject { get; }

        public OrderDishManager(IOrderDishDB orderdishDB)
        {
            OrderdishDBObject = orderdishDB;
        }

        public OrderDish AddOrderDish(OrderDish orderDish)
        {
            return OrderdishDBObject.AddOrderDish(orderDish);
        }

        public OrderDish GetOrderDish(int idOrder)
        {
            return OrderdishDBObject.GetOrderDish(idOrder);
        }

        public List<OrderDish> GetOrderDishes()
        {
            return OrderdishDBObject.GetOrderDishes();
        }
    }
}
