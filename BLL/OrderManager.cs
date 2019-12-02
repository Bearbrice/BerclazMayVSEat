using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class OrderManager : IOrderManager
    {
        public OrderDB OrderDB { get; }

        public OrderManager(IConfiguration configuration)
        {
            OrderDB = new OrderDB(configuration);
        }

        public List<Order> GetOrders()
        {
            return OrderDB.GetOrders();
        }

        public Order GetOrder(int id)
        {
            return OrderDB.GetOrder(id);
        }

        public Order AddOrder(Order Order)
        {
            return OrderDB.AddOrder(Order);
        }

        public int UpdateOrder(Order Order)
        {
            return OrderDB.UpdateOrder(Order);
        }

        public int DeleteOrder(int id)
        {
            return OrderDB.DeleteOrder(id);
        }
    }
}

