using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.Models
{
    public class OrderDishDetails
    {
        public int idOrder { get; set; }

        public int dishName { get; set; }

        public int dishPrice { get; set; }

        public DateTime scheduled { get; set; }


       

        //public override string ToString()
        //{
        //    return $"{fk_idDish}|{fk_idDish}|{quantity}";
        //}
    }
}
