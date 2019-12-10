using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class OrderDishDB : IOrderDishDB
    {
        private String ConnectionString = null;

        public OrderDishDB(IConfiguration configuration)
        {
            var config = configuration;
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }

        public List<OrderDish> GetOrderDishes(int id)
        {
            List<OrderDish> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM OrderDish WHERE fk_idOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDish>();

                            OrderDish orderDish = new OrderDish();

                            orderDish.fk_idOrder = (int)dr["fk_idOrder"];
                            orderDish.fk_idDish = (int)dr["fk_idDish"];
                            

                            results.Add(orderDish);
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

        public OrderDish GetOrderDish(int idOrder)
        {
            OrderDish orderDish = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM OrderDish WHERE fk_idOrder = @idOrder";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idOrder", idOrder);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            orderDish = new OrderDish();

                            orderDish.fk_idOrder = (int)dr["fk_idOrder"];
                            orderDish.fk_idDish = (int)dr["fk_idDish"];
                            

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orderDish;
        }

        public OrderDish AddOrderDish(OrderDish orderDish)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "INSERT INTO OrderDish(fk_idOrder, fk_idDish) values(@fk_idOrder, @fk_idDish)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@fk_idOrder", orderDish.fk_idOrder);
                    cmd.Parameters.AddWithValue("@fk_idDish", orderDish.fk_idDish);
                   

                    cn.Open();
                    cmd.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orderDish;
        }

        //UPDATE ????

        //DELETE ????
    }
}
