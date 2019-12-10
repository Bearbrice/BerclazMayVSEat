using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BLL
{
    public interface IOrdersManager
    {
        //IOrderDB OrderDB { get; }

        List<Orders> GetOrdersRelativeToStaff(string username);

        List<Orders> GetOrders();

        Orders GetOrder(int id);

        Orders AddOrder(Orders Order);

        int UpdateOrderById(int id);

        int UpdateOrder(Orders Order);

        int DeleteOrder(int id);
    }
}

