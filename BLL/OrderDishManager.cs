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
            throw new NotImplementedException();
        }

        public OrderDish GetOrderDish(int idOrder)
        { 
            throw new NotImplementedException();
        }

        public List<OrderDish> GetOrderDishes()
        {
            throw new NotImplementedException();
        }
    }
}
