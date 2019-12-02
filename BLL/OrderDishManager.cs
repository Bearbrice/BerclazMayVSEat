using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class OrderDishManager : IOrderDishManager
    {

        private IOrderDishManager OrderDishDbObject { get; }

        public OrderDishManager(IOrderDishManager orderDishDB)
        {
            OrderDishDbObject = orderDishDB;
        }

        public List<OrderDish> GetOrderDishes()
        {
            return OrderDishDbObject.GetOrderDishes();
        }

        public OrderDish GetOrderDish(int idOrder)
        {
            return OrderDishDbObject.GetOrderDish(idOrder);
        }

        public OrderDish AddOrderDish(OrderDish orderDish)
        {
            return OrderDishDbObject.AddOrderDish(orderDish);
        }

    }
}
