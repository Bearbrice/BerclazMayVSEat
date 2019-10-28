using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface IOrderDishManager
    {
        IOrderDishManager OrderDishDB { get; }

        List<OrderDish> GetOrderDishes();

        OrderDish GetOrderDish(int id);

        OrderDish AddOrderDish(OrderDish orderDish);

        //UPDATE ?
        //DELETE ?
    }
}
