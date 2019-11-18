using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Models
{
    public class Dish
    {
        public int idDish { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public int fk_idRestaurant { get; set; }

        public override string ToString()
        {
            return $"{idDish}|{name}|{price}|{status}|{created_at}|{fk_idRestaurant}";
        }
    }
}
