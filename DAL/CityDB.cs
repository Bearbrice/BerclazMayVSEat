using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class CityDB : ICityDB
    {

        private String connectionString = null;

        public CityDB(IConfiguration configuration)
        {
            var config = configuration;
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public List<City> GetCities()
        {
            List<City> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM City";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<City>();

                            City city = new City();

                            city.idCity = (int)dr["idCity"];
                            city.name = (string)dr["name"];
                            city.code = (int)dr["code"];

                            results.Add(city);
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

        //GetCity by id
        public City GetCity(int id)
        {
            City city = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM City WHERE idCity = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            city = new City();

                            city.idCity = (int)dr["idCity"];
                            city.code = (int)dr["code"];
                            city.name = (string)dr["name"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return city;

        }

        //Get city id by city code
        public int GetIdCity(int cityCode)
        {
            int idCity = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT idCity FROM City WHERE code = @cityCode";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@cityCode", cityCode);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            idCity = (int)dr["idCity"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return idCity;

        }


    }
}
