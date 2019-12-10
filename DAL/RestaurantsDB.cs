﻿using DTO;
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

        public List<Restaurant> GetRestaurants()
        {
            List<Restaurant> results = null;
           

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurant";
                    SqlCommand cmd = new SqlCommand(query, cn);

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

        public Restaurant GetRestaurant(int id)
        {
            Restaurant restaurant = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Restaurant WHERE IdRestaurant = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            restaurant = new Restaurant();

                            restaurant.IdRestaurant = (int)dr["IdRestaurant"];
                            restaurant.Name = (string)dr["Name"];
                            restaurant.Description = (string)dr["Description"];
                            restaurant.IdCity = (int)dr["IdCity"];
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
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Restaurant(Name, Description, IdCity) VALUES(@name, @descripton, @idCity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", restaurant.Name);
                    cmd.Parameters.AddWithValue("@description", restaurant.Description);
                    cmd.Parameters.AddWithValue("@idcountry", restaurant.IdCity);


                    cn.Open();

                    restaurant.IdRestaurant = Convert.ToInt32(cmd.ExecuteScalar());
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
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Restaurant SET Name=@name, Description=@description, IdCity=@idCity WHERE IdRestaurant=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", restaurant.IdRestaurant);
                    cmd.Parameters.AddWithValue("@name", restaurant.Name);
                    cmd.Parameters.AddWithValue("@idCity", restaurant.IdCity);


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
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Restaurant WHERE IdRestaurants=@id";
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
