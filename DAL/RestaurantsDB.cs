using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class RestaurantsDB : IRestaurantsDB
    {

        public IConfiguration Configuration { get; }
        public RestaurantsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";

        public List<Restaurant> GetRestaurants(int id)
        {
            List<Restaurant> results = null;
           

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurant WHERE IdCity = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Restaurant>();

                            Restaurant restaurants = new Restaurant();

                            restaurants.IdRestaurant = (int)dr["IdRestaurant"];
                            restaurants.Name = (string)dr["Name"];
                            restaurants.Description = (string)dr["Descritption"];
                            restaurants.IdCity = (int)dr["IdCity"];


                            results.Add(restaurants);
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
