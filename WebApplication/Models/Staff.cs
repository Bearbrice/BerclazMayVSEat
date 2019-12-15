﻿using System;

namespace WebApplication.Models
{
    public class Staff
    {
        public int idStaff { get; set; }
        public string full_name { get; set; }
        public DateTime hired_on { get; set; }
        public string telephone { get; set; }
        public int fk_idCity { get; set; }

        public override string ToString()
        {
            return $"{idStaff}|{full_name}|{hired_on}|{telephone}|{fk_idCity}";
        }
    }
}
