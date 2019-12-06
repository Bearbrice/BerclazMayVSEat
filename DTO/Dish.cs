﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Dish
    {
        public int idDish { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int fk_idRestaurant { get; set; }

        public override string ToString()
        {
            return $"{idDish}|{name}|{price}|{fk_idRestaurant}";
        }
    }
}
