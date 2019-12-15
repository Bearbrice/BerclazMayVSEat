using System;

namespace DTO
{
    public class Restaurant
    {
        public int idRestaurant { get; set; }
        public string merchant_name { get; set; }
        public DateTime created_at { get; set; }
        public int fk_idCity { get; set; }

        //Optional
        public override string ToString()
        {
            return $"{idRestaurant}|{merchant_name}|{created_at}|{fk_idCity}";
        }
    }
}
