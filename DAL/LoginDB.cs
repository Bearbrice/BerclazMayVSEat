﻿using Microsoft.Extensions.Configuration;
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

        //Method to add a Login
        public Login AddLogin(Login login, int idCustomer)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "INSERT INTO Login(idLogin, username, password, fk_customerId) values(@idLogin, @username, @password, @fk_customerId); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idLogin", 6);
                    cmd.Parameters.AddWithValue("@username", login.username);
                    cmd.Parameters.AddWithValue("@password", login.password);
                    cmd.Parameters.AddWithValue("@fk_customerId", idCustomer);
                    //cmd.Parameters.AddWithValue("@fk_customerId", login.fk_customerId);
                    //cmd.Parameters.AddWithValue("@fk_staffId", login.fk_staffId);

                    cn.Open();

                    //login.idLogin = 6;

                    //int temp = Convert.ToInt32(cmd.ExecuteScalar());

                    //login.idLogin = temp;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return login;
        }

        //Method to control (by his username) if the login is a customer or a staff
        public bool IsItACustomer(string username)
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT fk_customerId FROM Login WHERE username = @username";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@username", username);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            if (dr["fk_customerId"] == System.DBNull.Value)
                            {
                                return false;
                            }
                            else
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

        //Method to control if the login is valid
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
