using System;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using DTO;
using System.Collections.Generic;

namespace DAL
{
    public class CustomerDB : ICustomerDB
    {
        private String ConnectionString = null;

        public CustomerDB(IConfiguration configuration)
        {
            var config = configuration;
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }

        public List<Customer> GetCustomers()
        {
            List<Customer> results = null;

            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Customer";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customer>();

                            Customer customer = new Customer();

                            customer.idCustomer = (int)dr["idCustomer"];
                            customer.full_name = (string)dr["full_name"];
                            customer.created_at = (DateTime)dr["created_at"];
                            customer.telephone = (string)dr["telephone"];
                            customer.fk_idCity = (int)dr["fk_idCity"];

                            results.Add(customer);
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

        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Customer WHERE idCustomer = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customer = new Customer();

                            customer.idCustomer = (int)dr["idCustomer"];
                            customer.full_name = (string)dr["full_name"];
                            customer.created_at = (DateTime)dr["created_at"];
                            customer.telephone = (string)dr["telephone"];
                            customer.fk_idCity = (int)dr["fk_idCity"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;

        }

        public Customer AddCustomer(Customer customer)
        {
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "Insert into Customer(full_name, created_at, telephone, fk_idCity) values(@full_name, @created_at, @telephone, @fk_idCity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@full_name", customer.full_name);
                    cmd.Parameters.AddWithValue("@created_at", customer.created_at);
                    cmd.Parameters.AddWithValue("@telephone", customer.telephone);
                    cmd.Parameters.AddWithValue("@fk_idCity", customer.fk_idCity);

                    cn.Open();

                    customer.idCustomer = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }

        public int UpdateCustomer(Customer customer)
        {
            int result = 0;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "UPDATE Customer SET full_name=@full_name, created_at=@created_at, telephone=@telephone, fk_idCity=@fk_idCity WHERE idCustomer=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@full_name", customer.full_name);
                    cmd.Parameters.AddWithValue("@created_at", customer.created_at);
                    cmd.Parameters.AddWithValue("@telephone", customer.telephone);
                    cmd.Parameters.AddWithValue("@fk_idCity", customer.fk_idCity);

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

        public int DeleteCustomer(int id)
        {
            int result = 0;
            //string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "DELETE FROM Customer WHERE idCustomer=@id";
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
