using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class LoginDB : ILoginDB
    {
        private String ConnectionString = null;

        public LoginDB(IConfiguration configuration)
        {
            var config = configuration;
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }

        public bool IsLoginValid(Login login)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT username, password FROM Login";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (login.username.Equals((string)dr["username"]) && login.password.Equals((string)dr["password"]))
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return false;
        }
    }
}
