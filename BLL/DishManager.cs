using DAL;
using DTO;
using System.Collections.Generic;

namespace BLL
{
    public class DishManager : IDishManager
    {
        private IDishDB DishDBObject { get; }

        public DishManager(IDishDB dishDB)
        {
            DishDBObject = dishDB;
        }

        public List<Dish> GetDishes(int id)
        {
            return DishDBObject.GetDishes(id);
        }

        public Dish GetDish(int id)
        {
            return DishDBObject.GetDish(id);
        }

        public Dish AddDish(Dish dish)
        {
            return DishDBObject.AddDish(dish);
        }

        public int UpdateDish(Dish dish)
        {
            return DishDBObject.UpdateDish(dish);
        }

        public int DeleteDish(int id)
        {
            return DishDBObject.DeleteDish(id);
        }

    }
}
