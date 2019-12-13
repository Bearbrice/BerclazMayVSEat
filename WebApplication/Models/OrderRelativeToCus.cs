using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class OrderRelativeToCus
    {
        public int idOrder { get; set; }

        public String status { get; set; }

        public DateTime scheduled { get; set; }

        public DateTime delivered { get; set; }

        public String staffName { get; set; }
    }
}
