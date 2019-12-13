using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BLL
{
    public interface IOrdersManager
    {
        List<Orders> GetOrdersRelativeToStaff(string username);

        List<Orders> GetOrdersRelativeToCustomer(string username);

        List<Orders> GetOrders();

        Boolean isStaffOverbooked(int idStaff, DateTime hour);

        Orders GetOrder(int id);

        Orders AddOrder(Orders Order);

        Orders GetOrderInfo(int id);

        int UpdateOrderById(int id);

        int UpdateOrder(Orders Order);

        int DeleteOrder(int id);
    }
}

