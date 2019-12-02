using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class OrderManager : IOrderManager
    {
        private IOrderManager OrderDbObject { get; }

        public OrderManager(IOrderManager orderDB)
        {
            OrderDbObject = orderDB;
        }

        public List<Order> GetOrders()
        {
            return OrderDbObject.GetOrders();
        }

        public Order GetOrder(int id)
        {
            return OrderDbObject.GetOrder(id);
        }

        public Order AddOrder(Order Order)
        {
            return OrderDbObject.AddOrder(Order);
        }

        public int UpdateOrder(Order Order)
        {
            return OrderDbObject.UpdateOrder(Order);
        }

        public int DeleteOrder(int id)
        {
            return OrderDbObject.DeleteOrder(id);
        }
    }
}

