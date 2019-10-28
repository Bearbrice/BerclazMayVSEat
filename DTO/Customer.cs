using System;
using System.Configuration;

namespace DTO
{
    public class Customer
    {
        public int idCustomer { get; set; }
        public string full_name { get; set; }
        public DateTime created_at { get; set; }
        public string telephone { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public int fk_idCity { get; set; }
       

        public override string ToString()
        {
           return $"{idCustomer}|{full_name}|{created_at}|{telephone}|{login}|{password}|{fk_idCity}";
        }
    }
}
