using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class LoginDB : ILoginDB
    {
        public IConfiguration Configuration { get; }

        public LoginDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Login> GetLogins()
        {
            List<Login> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Login";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Login>();

                            Login login = new Login();

                            login.idLogin = (int)dr["idLogin"];
                            login.user = (string)dr["user"];
                            login.password = (string)dr["password"];
                            login.fk_customerId = (int)dr["fk_customerId"];
                            login.fk_staffId = (int)dr["fk_staffId"];

                            results.Add(login);
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

        public Login GetLogin(int id)
        {
            Login login = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Login WHERE idLogin = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            login = new Login();

                            login.idLogin = (int)dr["idLogin"];
                            login.user = (string)dr["user"];
                            login.password = (string)dr["password"];
                            login.fk_customerId = (int)dr["fk_customerId"];
                            login.fk_staffId = (int)dr["fk_staffId"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return login;
        }

        public Login AddLogin(Login login)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Login(user, password, fk_customerId, fk_staffId) values(@user, @password, @fk_customerId, @fk_staffId); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@login", login.user);
                    cmd.Parameters.AddWithValue("@password", login.password);
                    cmd.Parameters.AddWithValue("@fk_customerId", login.fk_customerId);
                    cmd.Parameters.AddWithValue("@fk_staffId", login.fk_staffId);

                    cn.Open();

                    login.idLogin = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return login;
        }

        public int UpdateLogin(Login login)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Login SET login=@user, password=@password, fk_customerId=@fk_customerId, fk_staffId=@fk_staffId WHERE idLogin=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", login.idLogin);
                    cmd.Parameters.AddWithValue("@user", login.user);
                    cmd.Parameters.AddWithValue("@password", login.password);
                    cmd.Parameters.AddWithValue("@fk_customerId", login.fk_customerId);
                    cmd.Parameters.AddWithValue("@fk_staffId", login.fk_staffId);

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

        public int DeleteLogin(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Login WHERE idLogin=@id";
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
