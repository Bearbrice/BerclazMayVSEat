using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class DishDB : IDishDB
    {
        private String ConnectionString = null;

        public DishDB(IConfiguration configuration)
        {
            var config = configuration;
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }

        public List<Dish> GetDishes(int id)
        {
            List<Dish> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Dish WHERE fk_idRestaurant=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dish>();

                            Dish dish = new Dish();

                            dish.idDish = (int)dr["idDish"];
                            dish.name = (string)dr["name"];
                            dish.price = (int)dr["price"];
                            dish.fk_idRestaurant = (int)dr["fk_idRestaurant"];

                            results.Add(dish);
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

        public Dish GetDish(int id)
        {
            Dish dish = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Dish WHERE idDish = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            dish = new Dish();

                            dish.idDish = (int)dr["idDish"];
                            dish.name = (string)dr["name"];
                            dish.price = (int)dr["price"];
                            dish.fk_idRestaurant = (int)dr["fk_idRestaurant"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }

        public Dish AddDish(Dish dish)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "Insert into Dish(name, price, fk_idRestaurant) values(@name, @price, @fk_idRestaurant); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", dish.name);
                    cmd.Parameters.AddWithValue("@price", dish.price);
                    cmd.Parameters.AddWithValue("@fk_idRestaurant", dish.fk_idRestaurant);

                    cn.Open();

                    dish.idDish = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }

        public int UpdateDish(Dish dish)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "UPDATE Dish SET name=@name, price=@price, fk_idRestaurant=@fk_idRestaurant WHERE idDish=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", dish.name);
                    cmd.Parameters.AddWithValue("@price", dish.price);
                    cmd.Parameters.AddWithValue("@fk_idRestaurant", dish.fk_idRestaurant);

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

        public int DeleteDish(int id)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "DELETE FROM Dish WHERE idDish=@id";
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
