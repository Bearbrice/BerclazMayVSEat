using System;

namespace WebApplication.Models
{
    public class OrderDishDetails
    {
        public int idOrder { get; set; }

        public String dishName { get; set; }

        public int dishPrice { get; set; }

        public DateTime scheduled { get; set; }

        public String status { get; set; }




        //public override string ToString()
        //{
        //    return $"{fk_idDish}|{fk_idDish}|{quantity}";
        //}
    }
}
