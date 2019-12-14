using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class Staff
    {
        public int idStaff { get; set; }
        public string full_name { get; set; }
        public DateTime hired_on { get; set; }
        public string telephone { get; set; }
        public int fk_idCity { get; set; }

        //Optional
        public override string ToString()
        {
            return $"{idStaff}|{full_name}|{hired_on}|{telephone}|{fk_idCity}";
        }
    }
}
