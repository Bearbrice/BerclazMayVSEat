using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrdersDB
    {
        
        List<Orders> GetOrdersRelativeToStaff(string username);

        List<Orders> GetOrdersRelativeToCustomer(string username);

        Boolean isStaffOverbooked(int idStaff, DateTime hour);

        List<Orders> GetOrders();

        Orders GetOrder(int id);

        Orders AddOrder(Orders order);

        Orders GetOrderInfo(int id);

        int UpdateOrderById(int id);

        int UpdateOrder(Orders order);

        int DeleteOrder(int id);
    }
}

