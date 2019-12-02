using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface IOrderManager
    {
        //IOrderDB OrderDB { get; }

        List<Order> GetOrders();

        Order GetOrder(int id);

        Order AddOrder(Order Order);

        int UpdateOrder(Order Order);

        int DeleteOrder(int id);
    }
}

