﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace WebApplication.Models
{
    public class City
    {
        public int idCity { get; set; }
        public int code { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return $"{idCity}|{code}|{name}";
        }
    }
}
