﻿using System;
using System.Collections.Generic;
using System.Configuration;

namespace WebApplication.Models
{
    public class Order
    {
        public int idOrder { get; set; }
        public string status { get; set; }
        public DateTime scheduled_at { get; set; }
        public DateTime finished_at { get; set; }
        public int fk_idStaff { get; set; }
        public int fk_idCustomer { get; set; }
       
    }
}
