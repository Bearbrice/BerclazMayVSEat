using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class OrderDishManager : IOrderDishManager
    {
        private IOrderDishDB OrderdishDBObject { get; }

        public OrderDishManager(IOrderDishDB orderdishDB)
        {
            OrderdishDBObject = orderdishDB;
        }

        public OrderDish AddOrderDish(OrderDish orderDish)
        {
            return OrderdishDBObject.AddOrderDish(orderDish);
        }

        public OrderDish GetOrderDish(int idOrder)
        {
            return OrderdishDBObject.GetOrderDish(idOrder);
        }

        public List<OrderDish> GetOrderDishes(int id)
        {
            return OrderdishDBObject.GetOrderDishes(id);
        }
    }
}
