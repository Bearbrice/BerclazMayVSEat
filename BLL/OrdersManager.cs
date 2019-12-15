using DAL;
using DTO;
using System;
using System.Collections.Generic;

namespace BLL
{
    public class OrdersManager : IOrdersManager
    {
        private IOrdersDB OrderDbObject { get; }

        public OrdersManager(IOrdersDB orderDB)
        {
            OrderDbObject = orderDB;
        }

        public Boolean isStaffOverbooked(int idStaff, DateTime hour)
        {
            return OrderDbObject.isStaffOverbooked(idStaff, hour);
        }

        public Orders GetOrderInfo(int id)
        {
            return OrderDbObject.GetOrderInfo(id);
        }

        public List<Orders> GetOrders()
        {
            return OrderDbObject.GetOrders();
        }

        public List<Orders> GetOrdersRelativeToCustomer(string username)
        {
            return OrderDbObject.GetOrdersRelativeToCustomer(username);
        }

        public List<Orders> GetOrdersRelativeToStaff(string username)
        {
            return OrderDbObject.GetOrdersRelativeToStaff(username);
        }

        public Orders GetOrder(int id)
        {
            return OrderDbObject.GetOrder(id);
        }

        public Orders AddOrder(Orders Order)
        {
            return OrderDbObject.AddOrder(Order);
        }

        public int UpdateOrderById(int id)
        {
            return OrderDbObject.UpdateOrderById(id);
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

