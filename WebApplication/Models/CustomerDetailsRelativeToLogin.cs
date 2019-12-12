using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class CustomerDetailsRelativeToLogin
    {
        public int fullName { get; set; }

        public DateTime created { get; set; }

        public string phone { get; set; }

        public string user { get; set; }
    }
}
