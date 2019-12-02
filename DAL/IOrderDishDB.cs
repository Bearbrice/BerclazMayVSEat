using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;

namespace DAL
{
    public interface IOrderDishDB
    {
        //IConfiguration Configuration { get; }

        List<OrderDish> GetOrderDishes();

        OrderDish GetOrderDish(int idOrder);

        OrderDish AddOrderDish(OrderDish orderDish);
    }
}
