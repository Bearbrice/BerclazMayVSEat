using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public interface IOrderdishManager
    {
        List<OrderDish> GetOrderDishes();

        OrderDish GetOrderDish(int idOrder);

        OrderDish AddOrderDish(OrderDish orderDish);
    }
}
