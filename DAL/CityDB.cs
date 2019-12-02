using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class CityDB : ICityDB
    {
        //public IConfiguration Configuration { get; }

        //public CityDB(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        private String connectionString = null;

        public CityDB(IConfiguration configuration)
        {
            var config = configuration;
            connectionString = config.GetConnectionString("DefaultConnection");
        }

        public List<City> GetCities()
        {
            List<City> results = null;
           // string connectionString = Configuration.GetConnectionString("DefaultConnection");

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

        //public City GetCity(int id)
        //{
        //    City city = null;
        //    string connectionString = Configuration.GetConnectionString("DefaultConnection");

        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(connectionString))
        //        {
        //            string query = "SELECT * FROM City WHERE idCity = @id";
        //            SqlCommand cmd = new SqlCommand(query, cn);
        //            cmd.Parameters.AddWithValue("@id", id);

        //            cn.Open();

        //            using (SqlDataReader dr = cmd.ExecuteReader())
        //            {
        //                if (dr.Read())
        //                {
        //                    city = new City();

        //                    city.idCity = (int)dr["idCity"];
        //                    city.name = (string)dr["name"];
        //                    city.code = (int)dr["code"];

        //                }
        //            }
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //    return city;
        //}

        //public City AddCity(City city)
        //{
        //    string connectionString = Configuration.GetConnectionString("DefaultConnection");

        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(connectionString))
        //        {
        //            string query = "INSERT INTO City(code, name) values(@code, @name); SELECT SCOPE_IDENTITY()";
        //            SqlCommand cmd = new SqlCommand(query, cn);
        //            cmd.Parameters.AddWithValue("@code", city.code);
        //            cmd.Parameters.AddWithValue("@name", city.name);

        //            cn.Open();

        //            city.idCity = Convert.ToInt32(cmd.ExecuteScalar());
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //    return city;
        //}

        //public int UpdateCity(City city)
        //{
        //    int result = 0;
        //    string connectionString = Configuration.GetConnectionString("DefaultConnection");

        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(connectionString))
        //        {
        //            string query = "UPDATE City SET code=@code, name=@name WHERE idCity=@id";
        //            SqlCommand cmd = new SqlCommand(query, cn);
        //            cmd.Parameters.AddWithValue("@id", city.idCity);
        //            cmd.Parameters.AddWithValue("@code", city.code);
        //            cmd.Parameters.AddWithValue("@name", city.name);

        //            cn.Open();

        //            result = cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //    return result;
        //}

        //public int DeleteCity(int id)
        //{
        //    int result = 0;
        //    string connectionString = Configuration.GetConnectionString("DefaultConnection");

        //    try
        //    {
        //        using (SqlConnection cn = new SqlConnection(connectionString))
        //        {
        //            string query = "DELETE FROM City WHERE idCity=@id";
        //            SqlCommand cmd = new SqlCommand(query, cn);
        //            cmd.Parameters.AddWithValue("@id", id);

        //            cn.Open();

        //            result = cmd.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }

        //    return result;
        //}
    }
}
