﻿using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class OrderDetailForStaff
    {
        internal object dishesNames;

        public int idOrder { get; set; }

        public String status { get; set; }

        public DateTime scheduled { get; set; }

        public DateTime delivered { get; set; }

        public String customerName { get; set; }

        public String telepone { get; set; }

        public String cityName { get; set; }

        public List<String> dishesName { get; set; }
    }
}