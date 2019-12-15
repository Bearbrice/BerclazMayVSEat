using DTO;
using System.Collections.Generic;

namespace DAL
{
    public interface IOrderDishDB
    {
        List<OrderDish> GetOrderDishes(int id);

        OrderDish GetOrderDish(int idOrder);

        OrderDish AddOrderDish(OrderDish orderDish);
    }
}
