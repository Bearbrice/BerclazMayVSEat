using System;

namespace WebApplication.Models
{
    public class OrderRelativeToCustomer
    {
        public int idOrder { get; set; }

        public String status { get; set; }

        public DateTime scheduled { get; set; }

        public DateTime delivered { get; set; }

        public String staffName { get; set; }
    }
}
