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
        public DishDB DishDB { get; }

        public DishManager(IConfiguration configuration)
        {
            DishDB = new DishDB(configuration);
        }

        public List<Dish> GetDishes()
        {
            return DishDB.GetDishes();
        }

        public Dish GetDish(int id)
        {
            return DishDB.GetDish(id);
        }

        public Dish AddDish(Dish dish)
        {
            return DishDB.AddDish(dish);
        }
        public int UpdateDish(Dish dish)
        {
            return DishDB.UpdateDish(dish);
        }
        public int DeleteDish(int id)
        {
            return DishDB.DeleteDish(id);
        }
    }
}
