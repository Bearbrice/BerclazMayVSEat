using System;
using System.Collections.Generic;
using System.Text;
using DAL;
using DTO;
using Microsoft.Extensions.Configuration;

namespace BLL
{
    public class DishManager : IDishManager
    {
        private IDishManager DishDbObject { get; }

        public DishManager(IDishManager dishDB)
        {
            DishDbObject = dishDB;
        }

        public List<Dish> GetDishes()
        {
            return DishDbObject.GetDishes();
        }

        public Dish GetDish(int id)
        {
            return DishDbObject.GetDish(id);
        }

        public Dish AddDish(Dish dish)
        {
            return DishDbObject.AddDish(dish);
        }
        public int UpdateDish(Dish dish)
        {
            return DishDbObject.UpdateDish(dish);
        }
        public int DeleteDish(int id)
        {
            return DishDbObject.DeleteDish(id);
        }
    }
}
