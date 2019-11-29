using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace DTO
{
    public class Login
    {
        public int idLogin { get; set; }
        public string user { get; set; }
        public string password { get; set; }
        public int fk_customerId { get; set; }
        public int fk_staffId { get; set; }

        public override string ToString()
        {
            return $"{idLogin}|{login}|{password}|{fk_customerId}|{fk_staffId}";
        }
    }
}
