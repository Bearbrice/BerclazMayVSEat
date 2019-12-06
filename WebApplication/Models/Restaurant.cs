using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace WebApplication.Models
{
    public class Restaurant
    {
        public int idRestaurant { get; set; }
        public string merchant_name { get; set; }
        public DateTime created_at { get; set; }
        public int fk_idCity { get; set; }

        public String CityName;

        public override string ToString()
        {
            return $"{idRestaurant}|{merchant_name}|{created_at}|{fk_idCity}";
        }
    }
}
