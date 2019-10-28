using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class OrderDishManager
    {

        public OrderDishDB OrderDishDB { get; }

        public OrderDishManager(IConfiguration configuration)
        {
            OrderDishDB = new OrderDishDB(configuration);
        }

        public List<OrderDish> GetOrderDishes()
        {
            return OrderDishDB.GetOrderDishes();
        }

        public OrderDish GetOrderDish(int idOrder)
        {
            return OrderDishDB.GetOrderDish(idOrder);
        }

        public OrderDish AddOrderDish(OrderDish orderDish)
        {
            return OrderDishDB.AddOrderDish(orderDish);
        }

    }
}
