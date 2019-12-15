using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL
{
    public class StaffDB : IStaffDB
    {
        private String ConnectionString = null;

        public StaffDB(IConfiguration configuration)
        {
            var config = configuration;
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }

        public List<Staff> GetStaffsByCity(int idCity)
        {
            List<Staff> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Staff WHERE fk_idCity=@idCity";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCity", idCity);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Staff>();

                            Staff staff = new Staff();

                            staff.idStaff = (int)dr["idStaff"];
                            staff.full_name = (string)dr["full_name"];
                            staff.hired_on = (DateTime)dr["hired_on"];
                            staff.telephone = (string)dr["telephone"];
                            staff.fk_idCity = (int)dr["fk_idCity"];

                            results.Add(staff);
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

        public List<Staff> GetStaffs()
        {
            List<Staff> results = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Staff";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Staff>();

                            Staff staff = new Staff();

                            staff.idStaff = (int)dr["idStaff"];
                            staff.full_name = (string)dr["full_name"];
                            staff.hired_on = (DateTime)dr["hired_on"];
                            staff.telephone = (string)dr["telephone"];
                            staff.fk_idCity = (int)dr["fk_idCity"];

                            results.Add(staff);
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

        public Staff GetStaff(int id)
        {
            Staff staff = null;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "SELECT * FROM Staff WHERE idStaff = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            staff = new Staff();

                            staff.idStaff = (int)dr["idStaff"];
                            staff.full_name = (string)dr["full_name"];
                            staff.hired_on = (DateTime)dr["hired_on"];
                            staff.telephone = (string)dr["telephone"];
                            staff.fk_idCity = (int)dr["fk_idCity"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return staff;
        }

        public Staff AddStaff(Staff staff)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "INSERT INTO Staff(full_name, hired_on, telephone, fk_idCity) values(@full_name, @hired_on, @telephone, @fk_idCity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@full_name", staff.full_name);
                    cmd.Parameters.AddWithValue("@hired_on", staff.hired_on);
                    cmd.Parameters.AddWithValue("@telephone", staff.telephone);
                    cmd.Parameters.AddWithValue("@fk_idCity", staff.fk_idCity);

                    cn.Open();

                    staff.idStaff = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return staff;
        }

        public int UpdateStaff(Staff staff)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "UPDATE Staff SET merchant_name=@merchant_name, created_at=@created_at, fk_idCity=@fk_idCity WHERE idCity=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", staff.idStaff);
                    cmd.Parameters.AddWithValue("@full_name", staff.full_name);
                    cmd.Parameters.AddWithValue("@hired_on", staff.hired_on);
                    cmd.Parameters.AddWithValue("@telephone", staff.telephone);
                    cmd.Parameters.AddWithValue("@fk_idCity", staff.fk_idCity);

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

        public int DeleteStaff(int id)
        {
            int result = 0;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    string query = "DELETE FROM Staff WHERE idCity=@id";
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
