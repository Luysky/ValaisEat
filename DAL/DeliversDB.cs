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

        public List<Deliver> GetDelivers(int id)
        {
            List<Deliver> results = null;
          

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Deliver WHERE IdCity = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

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
                            delivers.PhoneNumber = (string)dr["PhoneNumber"];
                            delivers.IdCity = (int)dr["IdCity"];


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


    }
}
