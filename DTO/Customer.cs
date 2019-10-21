using System;
using System.Configuration;

namespace DTO
{
    public class Customer
    {
        public int idCustomer { get; set; }
        public string full_name { get; set; }
        public string created_at { get; set; }
        public string telephone { get; set; }
        public int login { get; set; }
        public bool password { get; set; }
        public bool fk_idCity { get; set; }
       

        /*public override string ToString()
        {
           // return $"{IdHotel}|{Name}|{Description}|{Location}|{Category.ToString()}|{HasWifi.ToString()}|{Phone}|{Email}|{Website}";
        }*/
    }
}
