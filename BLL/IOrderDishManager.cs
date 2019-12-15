using DTO;
using System.Collections.Generic;

namespace BLL
{
    public interface IOrderDishManager
    {
        List<OrderDish> GetOrderDishes(int id);

        OrderDish GetOrderDish(int idOrder);

        OrderDish AddOrderDish(OrderDish orderDish);
    }
}
