using System;
using System.Configuration;

namespace DTO
{
    public class Orders
    {
        public int idOrder { get; set; }
        public string status { get; set; }
        public DateTime scheduled_at { get; set; }
        public DateTime delivered_at { get; set; }
        public int fk_idStaff { get; set; }
        public int fk_idCustomer { get; set; }

        //Optional
        public override string ToString()
        {
           return $"{idOrder}|{status}|{scheduled_at}|{delivered_at}|{fk_idStaff}|{fk_idCustomer}";
        }
    }
}
