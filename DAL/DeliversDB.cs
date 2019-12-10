using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DeliversDB : IDeliversDB
    {

        public IConfiguration Configuration { get; }
        public DeliversDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";

        public List<Deliver> GetDelivers()
        {
            List<Deliver> results = null;
          

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Deliver";
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
                            delivers.Email = (string)dr["Email"];
                            delivers.Password = (string)dr["Password"];


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
        

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Deliver WHERE idDeliver = @id";
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
                            deliver.Email = (string)dr["Email"];
                            
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
           

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Deliver(Name, PhoneNumber, IdArea, Email) VALUES(@name, @phoneNumber, @idArea, @email); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", deliver.Name);
                    cmd.Parameters.AddWithValue("@adresse", deliver.PhoneNumber);
                    cmd.Parameters.AddWithValue("@idArea", deliver.IdArea);
                    cmd.Parameters.AddWithValue("@email", deliver.Email);


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
          

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Deliver SET Name=@name, PhoneNumber=@phoneNumber, IdArea=@idArea, Email=@email WHERE IdDeliver=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", deliver.IdDeliver);
                    cmd.Parameters.AddWithValue("@name", deliver.Name);
                    cmd.Parameters.AddWithValue("@phoneNumber", deliver.PhoneNumber);
                    cmd.Parameters.AddWithValue("@idArea", deliver.IdArea);
                    cmd.Parameters.AddWithValue("@email", deliver.Email);


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
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Deliver WHERE IdDeliver=@id";
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

        public bool IsUserValid(Deliver d, string email)
        {
            if (d.Email == email)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
