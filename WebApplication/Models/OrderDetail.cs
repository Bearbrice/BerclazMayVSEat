using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTO;

namespace WebApplication.Models
{
    public class OrderDetail : IOrderDetail
    {
        

        private IOrderDetail OrderDetailDBObject { get; set; }

        List<DTO.Dish> Dishes { get; set; }

        //public List<City> GetCities()
        //{
        //    return CityDBObject.GetCities();
        //}



        public List<DTO.Dish> GetDishes()
        {
            return Dishes;
        }

        public void Add(DTO.Dish dish)
        {
            Dishes.Add(dish);
        }



    }
    
}
