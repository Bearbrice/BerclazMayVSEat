using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class OrderDetail
    {

        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }

        public int idDish { get; set; }
        public string name { get; set; }
        public int price { get; set; }
        public int fk_idRestaurant { get; set; }
        public int Quantity { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Order Order { get; set; }

    }
    
}
