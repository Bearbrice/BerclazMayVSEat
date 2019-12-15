using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class RestaurantDB : IRestaurantDB
    {
        private String ConnectionString = null;

        public RestaurantDB(IConfiguration configuration)
        {
            var config = configuration;
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }

        public String GetCityName(int id)
        {
            String CityName = null;
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT C.name" +
                        "FROM Restaurant R, City C" +
                        "WHERE R.fk_idCity=C.idCity" +
                        "AND idRestaurant = @id";

                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            CityName = (string)dr["C.name"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return CityName;
        }

        public List<Restaurant> GetRestaurants(int id)
        {
            List<Restaurant> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Restaurant WHERE fk_idCity = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurant = new Restaurant();

                            restaurant.idRestaurant = (int)dr["idRestaurant"];
                            restaurant.merchant_name = (string)dr["merchant_name"];
                            restaurant.created_at = (DateTime)dr["created_at"];
                            restaurant.fk_idCity = (int)dr["fk_idCity"];

                            results.Add(restaurant);
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

        public Restaurant GetRestaurant(int id)
        {
            Restaurant restaurant = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Restaurant WHERE idRestaurant = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurant = new Restaurant();

                            restaurant.idRestaurant = (int)dr["idRestaurant"];
                            restaurant.merchant_name = (string)dr["merchant_name"];
                            restaurant.created_at = (DateTime)dr["created_at"];
                            restaurant.fk_idCity = (int)dr["fk_idCity"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "INSERT INTO Restaurant(merchant_name, created_at, fk_idCity) values(@merchant_name, @created_at, @fk_idCity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@code", restaurant.merchant_name);
                    cmd.Parameters.AddWithValue("@name", restaurant.created_at);
                    cmd.Parameters.AddWithValue("@name", restaurant.fk_idCity);

                    cn.Open();

                    restaurant.idRestaurant = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return restaurant;
        }

        public int UpdateRestaurant(Restaurant restaurant)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "UPDATE Restaurant SET merchant_name=@merchant_name, created_at=@created_at, fk_idCity=@fk_idCity WHERE idCity=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", restaurant.idRestaurant);
                    cmd.Parameters.AddWithValue("@merchant_name", restaurant.merchant_name);
                    cmd.Parameters.AddWithValue("@created_at", restaurant.created_at);
                    cmd.Parameters.AddWithValue("@fk_idCity", restaurant.fk_idCity);

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

        public int DeleteRestaurant(int id)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "DELETE FROM Restaurant WHERE idCity=@id";
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
