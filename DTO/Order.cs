using System;
using System.Configuration;

namespace DTO
{
    public class Order
    {
        public int idOrder { get; set; }
        public string status { get; set; }
        public DateTime scheduled_at { get; set; }
        public DateTime finished_at { get; set; }
        public int fk_idStaff { get; set; }
        public int fk_idCustomer { get; set; }
       

        public override string ToString()
        {
           return $"{idOrder}|{status}|{scheduled_at}|{finished_at}|{fk_idStaff}|{fk_idCustomer}";
        }
    }
}
