using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    class DeliversDB : IDeliversDB
    {

        public IConfiguration Configuration { get; }
        public DeliversDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Deliver> GetDelivers()
        {
            List<Deliver> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Delivers";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Deliver>();

                            Deliver delivers = new Deliver();

                            delivers.IdDeliver = (int)dr["IdDeliver"];
                            delivers.Name = (string)dr["Name"];
                            delivers.PhoneNumber = (int)dr["PhoneNumber"];
                            delivers.IdArea = (int)dr["IdArea"];


                            results.Add(delivers);

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

        public Deliver GetDeliver(int id)
        {
            Deliver deliver = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Delivers WHERE idDeliver = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            deliver = new Deliver();

                            deliver.IdDeliver = (int)dr["IdDeliver"];
                            deliver.Name = (string)dr["Name"];
                            deliver.PhoneNumber = (int)dr["PhoneNumber"];
                            deliver.IdArea = (int)dr["IdArea"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliver;
        }

        public Deliver AddDeliver(Deliver deliver)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Delivers(name, phoneNumber, idArea) VALUES(@name, @phoneNumber, @idArea); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", deliver.Name);
                    cmd.Parameters.AddWithValue("@adresse", deliver.PhoneNumber);
                    cmd.Parameters.AddWithValue("@idArea", deliver.IdArea);


                    cn.Open();

                    deliver.IdDeliver = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return deliver;
        }

        public int UpdateDeliver(Deliver deliver)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Delivers SET name=@name, phoneNumber=@phoneNumber, idArea=@idArea WHERE idDeliver=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", deliver.IdDeliver);
                    cmd.Parameters.AddWithValue("@name", deliver.Name);
                    cmd.Parameters.AddWithValue("@phoneNumber", deliver.PhoneNumber);
                    cmd.Parameters.AddWithValue("@idArea", deliver.IdArea);


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

        public int DeleteDeliver(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Delivers WHERE idDeliver=@id";
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
