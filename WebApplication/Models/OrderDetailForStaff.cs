﻿using System;
using System.Collections.Generic;

namespace WebApplication.Models
{
    public class OrderDetailForStaff
    {
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
