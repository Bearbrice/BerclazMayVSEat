using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using DAL;
using DTO;

namespace BLL
{
    public class OrdersManager : IOrdersManager
    {
        private IOrdersDB OrderDbObject { get; }

        public OrdersManager(IOrdersDB orderDB)
        {
            OrderDbObject = orderDB;
        }

        public List<Orders> GetOrders()
        {
            return OrderDbObject.GetOrders();
        }

        public Orders GetOrder(int id)
        {
            return OrderDbObject.GetOrder(id);
        }

        public Orders AddOrder(Orders Order)
        {
            return OrderDbObject.AddOrder(Order);
        }

        public int UpdateOrder(Orders Order)
        {
            return OrderDbObject.UpdateOrder(Order);
        }

        public int DeleteOrder(int id)
        {
            return OrderDbObject.DeleteOrder(id);
        }
    }
}

