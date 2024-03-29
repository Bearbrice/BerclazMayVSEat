﻿using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace DAL
{
    public class OrdersDB : IOrdersDB
    {
        private String ConnectionString = null;

        public OrdersDB(IConfiguration configuration)
        {
            var config = configuration;
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }

        //Check if Staff have more than 5 orders in the next 30 minutes
        public Boolean isStaffOverbooked(int idStaff, DateTime hour)
        {
            int count = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Orders WHERE fk_idStaff=@id AND status=@status";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idStaff);
                    cmd.Parameters.AddWithValue("@status", "ongoing");

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var scheduled = (DateTime)dr["scheduled_at"];

                            if (scheduled >= hour.AddMinutes(-15) && scheduled <= hour.AddMinutes(15))
                            {
                                count++;
                            }
                        }
                    }
                }
            }
            catch
            {
                return false;
            }

            if (count >= 5)
            {
                return true;
            }
            return false;
        }

        public List<Orders> GetOrdersRelativeToStaff(string username)
        {
            List<Orders> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {

                    string query = "SELECT idOrder, status, scheduled_at, delivered_at, fk_idCustomer FROM Orders O, Staff S, Login L " +
                                    "WHERE O.fk_idStaff = S.idStaff " +
                                    "AND L.fk_staffId = S.idStaff " +
                                    "AND @username = L.username " +
                                    "ORDER BY status DESC, scheduled_at, delivered_at";


                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@username", username);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Orders>();

                            Orders order = new Orders();

                            order.idOrder = (int)dr["idOrder"];
                            order.status = (string)dr["status"];
                            order.scheduled_at = (DateTime)dr["scheduled_at"];
                            if (dr["delivered_at"] != System.DBNull.Value)
                                order.delivered_at = (DateTime)dr["delivered_at"];
                            if (dr["fk_idCustomer"] != System.DBNull.Value)
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


        public List<Orders> GetOrdersRelativeToCustomer(string username)
        {
            List<Orders> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT idOrder, status, scheduled_at, delivered_at, fk_idStaff FROM Orders O, Customer C, Login L " +
                                    "WHERE O.fk_idCustomer = C.idCustomer " +
                                    "AND L.fk_customerId = C.idCustomer " +
                                    "AND @username = L.username " +
                                    "ORDER BY status DESC, scheduled_at, delivered_at";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@username", username);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Orders>();

                            Orders order = new Orders();

                            order.idOrder = (int)dr["idOrder"];
                            order.status = (string)dr["status"];
                            order.scheduled_at = (DateTime)dr["scheduled_at"];
                            if (dr["delivered_at"] != System.DBNull.Value)
                            {
                                order.delivered_at = (DateTime)dr["delivered_at"];
                            }


                            //problem here
                            if (dr["fk_idStaff"] != System.DBNull.Value)
                            {
                                order.fk_idStaff = (int)dr["fk_idStaff"];
                            }


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

        public List<Orders> GetOrders()
        {
            List<Orders> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Orders";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Orders>();

                            Orders order = new Orders();

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

        public Orders GetOrder(int id)
        {
            Orders order = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Orders WHERE idOrder = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order = new Orders();

                            order.idOrder = (int)dr["idOrder"];
                            order.status = (string)dr["status"];
                            order.scheduled_at = (DateTime)dr["scheduled_at"];
                            if (!dr["delivered_at"].Equals(System.DBNull.Value))
                            {
                                order.delivered_at = (DateTime)dr["delivered_at"];
                            }
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

        //Brice
        public Orders GetOrderInfo(int id)
        {
            Orders order = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Orders WHERE idOrder = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order = new Orders();

                            order.idOrder = (int)dr["idOrder"];
                            order.status = (string)dr["status"];
                            order.scheduled_at = (DateTime)dr["scheduled_at"];


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

        public Orders AddOrder(Orders order)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "INSERT INTO Orders(status, scheduled_at) VALUES(@status, @scheduled_at); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    //cmd.Parameters.AddWithValue("@idOrder", order.idOrder);
                    cmd.Parameters.AddWithValue("@status", order.status);

                    SqlDateTime myDateTime = order.scheduled_at;
                    cmd.Parameters.AddWithValue("@scheduled_at", myDateTime);

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

        //Update method for the btn delivered when a staff is connected
        public int UpdateOrderById(int id)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "UPDATE Orders SET status='delivered', delivered_at=CURRENT_TIMESTAMP WHERE idOrder=@id";
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

        //UPDATE THE ORDER WITHOUT THE DELIVERED_AT
        public int UpdateOrder(Orders order)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "UPDATE Orders SET status=@status, scheduled_at=@scheduled_at, fk_idStaff=@fk_idStaff, fk_idCustomer=@fk_idCustomer WHERE idOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", order.idOrder);
                    cmd.Parameters.AddWithValue("@status", order.status);
                    cmd.Parameters.AddWithValue("@scheduled_at", order.scheduled_at);


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

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "DELETE FROM Orders WHERE idOrder=@id";
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

