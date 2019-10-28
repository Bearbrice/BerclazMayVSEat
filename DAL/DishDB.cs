using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;
using Microsoft.Extensions.Configuration;

namespace DAL
{
    public class DishDB : IDishDB
    {
        public IConfiguration Configuration { get; }

        public DishDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Dish> GetDishes()
        {
            List<Dish> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dish";
                    SqlCommand cmd = new SqlCommand(query, cn);

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

                            if (dr["status"] != null)
                                dish.status = (string)dr["status"];

                            dish.created_at = (DateTime)dr["created_at"];
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
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

                            if (dr["status"] != null)
                                dish.status = (string)dr["status"];

                            dish.created_at = (DateTime)dr["created_at"];
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "Insert into Dish(name, price, status, created_at, fk_idRestaurant) values(@name, @price, @status, @created_at, @fk_idRestaurant); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", dish.name);
                    cmd.Parameters.AddWithValue("@price", dish.price);
                    cmd.Parameters.AddWithValue("@status", dish.status);
                    cmd.Parameters.AddWithValue("@created_at", dish.created_at);
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Dish SET name=@name, price=@price, status=@status, created_at=@created_at, fk_idRestaurant=@fk_idRestaurant WHERE idDish=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", dish.name);
                    cmd.Parameters.AddWithValue("@price", dish.price);
                    cmd.Parameters.AddWithValue("@status", dish.status);
                    cmd.Parameters.AddWithValue("@created_at", dish.created_at);
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
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
