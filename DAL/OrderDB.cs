﻿using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;
using System.Collections.Generic;

namespace DAL
{
    public class OrderDB : IOrderDB
    {
        private String ConnectionString = null;

        public OrderDB(IConfiguration configuration)
        {
            var config = configuration;
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }

        public List<Order> GetOrders()
        {
            List<Order> results = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Order";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order order = new Order();

                            order.idOrder = (int)dr["idOrder"];
                            order.status = (string)dr["status"];
                            order.scheduled_at = (DateTime)dr["scheduled_at"];
                            order.delivered_at = (DateTime)dr["delivered_at"];
                            order.fk_idStaff = (int)dr["fk_idStaff"];
                            order.fk_idCustomer = (int)dr["fk_idCustomer"];
                            

                            results.Add(order);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return results;
        }

        public Order GetOrder(int id)
        {
            Order order = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Order WHERE idOrder = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order = new Order();

                            order.idOrder = (int)dr["idOrder"];
                            order.status = (string)dr["status"];
                            order.scheduled_at = (DateTime)dr["scheduled_at"];
                            order.delivered_at = (DateTime)dr["delivered_at"];
                            order.fk_idStaff = (int)dr["fk_idStaff"];
                            order.fk_idCustomer = (int)dr["fk_idCustomer"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;

        }

        public Order AddOrder(Order order)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "Insert into Order(status, created_at, delivered_at, fk_idStaff, fk_idCustomer) values(@status, @created_at, @finished_at, @fk_idStaff, @fk_idCustomer); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    cmd.Parameters.AddWithValue("@scheduled_at", order.scheduled_at);
                    cmd.Parameters.AddWithValue("@delivered_at", order.delivered_at);
                    cmd.Parameters.AddWithValue("@fk_idStaff", order.fk_idStaff);
                    cmd.Parameters.AddWithValue("@fk_idCustomer", order.fk_idCustomer);

                    cn.Open();

                    order.idOrder = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public int UpdateOrder(Order order)
        {
            int result = 0;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "UPDATE Order SET status=@status, created_at=@created_at, finished_at=@finished_at, fk_idStaff=@fk_idStaff, fk_idCustomer=@fk_idCustomer WHERE idOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    cmd.Parameters.AddWithValue("@scheduled_at", order.scheduled_at);
                    cmd.Parameters.AddWithValue("@delivered_at", order.delivered_at);
                    cmd.Parameters.AddWithValue("@fk_idStaff", order.fk_idStaff);
                    cmd.Parameters.AddWithValue("@fk_idCustomer", order.fk_idCustomer);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }

        public int DeleteOrder(int id)
        {
            int result = 0;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "DELETE FROM Order WHERE idOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    result = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return result;
        }
    }
}

