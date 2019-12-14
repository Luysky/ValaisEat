using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DishesDB : IDishesDB
    {

        public IConfiguration Configuration { get; }
        public DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";

        public List<Dish> GetDishes(int id)
        {
            List<Dish> results = null;
          

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dish WHERE IdRestaurant = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Dish>();

                            Dish dishes = new Dish();

                            dishes.IdDish = (int)dr["IdDish"];
                            dishes.Name = (string)dr["Name"];
                            dishes.DishPrice = (decimal)dr["DishPrice"];
                            dishes.Status = (string)dr["Status"];
                            dishes.IdRestaurant = (int)dr["IdRestaurant"];


                            results.Add(dishes);
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

        public Dish GetDish(int id)
        {
            Dish dish = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dish WHERE IdDish = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {

                            dish = new Dish();

                            dish.IdDish = (int)dr["IdDish"];
                            dish.Name = (string)dr["Name"];
                            dish.DishPrice = (decimal)dr["DishPrice"];
                            dish.Status = (string)dr["Status"];
                            dish.IdRestaurant = (int)dr["IdRestaurant"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }



    }
}
