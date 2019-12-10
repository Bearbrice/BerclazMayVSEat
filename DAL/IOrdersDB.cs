using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public interface IOrdersDB
    {
        //IConfiguration Configuration { get; }

        List<Orders> GetOrdersRelativeToStaff(string username);

        List<Orders> GetOrders();

        Orders GetOrder(int id);

        Orders AddOrder(Orders order);

        int UpdateOrderById(int id);

        int UpdateOrder(Orders order);

        int DeleteOrder(int id);
    }
}

