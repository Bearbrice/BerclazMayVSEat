using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace BLL
{
    public interface IOrdersManager
    {
        //IOrderDB OrderDB { get; }

        List<Orders> GetOrders();

        Orders GetOrder(int id);

        Orders AddOrder(Orders Order);

        int UpdateOrder(Orders Order);

        int DeleteOrder(int id);
    }
}

