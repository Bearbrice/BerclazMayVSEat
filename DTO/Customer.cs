using System;
using System.Configuration;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class Customer
    {
        public int idCustomer { get; set; }
        public string full_name { get; set; }
        public DateTime created_at { get; set; }

        [Phone]
        public string telephone { get; set; }
        public int fk_idCity { get; set; }

        //Optional
        public override string ToString()
        {
           return $"{idCustomer}|{full_name}|{created_at}|{telephone}|{fk_idCity}";
        }
    }
}
