using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    class DishesDB
    {

        public IConfiguration Configuration { get; }
        public DishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<Dish> GetDishes()
        {
            List<Dish> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dishes";
                    SqlCommand cmd = new SqlCommand(query, cn);

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
                            dishes.DishPrice = (int)dr["DishPrice"];
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Dishes WHERE idDish = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {

                            if (dr.Read())
                        
                            dish = new Dish();

                            dish.IdDish = (int)dr["IdDish"];
                            dish.Name = (string)dr["Name"];
                            dish.DishPrice = (int)dr["DishPrice"];
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

        public Dish AddDish(Dish dish)
        {
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Dishes(name, dishPrice, status, idrestaurant) VALUES(@name, @dishPrice, @status, @idrestaurant); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", dish.Name);
                    cmd.Parameters.AddWithValue("@dishPrice", dish.DishPrice);
                    cmd.Parameters.AddWithValue("@status", dish.Status);
                    cmd.Parameters.AddWithValue("@idrestaurant", dish.IdRestaurant);
                  


                    cn.Open();

                    dish.IdDish = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return dish;
        }

        public int UpdateDish(Dish dish)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Areas SET idDish=@idDish, name=@name, dishPrice=@dishPrice, status = @status, idRestaurant=@idRestaurant WHERE idDish=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idDish", dish.IdDish);
                    cmd.Parameters.AddWithValue("@name", dish.Name);
                    cmd.Parameters.AddWithValue("@dishPrice", dish.DishPrice);
                    cmd.Parameters.AddWithValue("@status", dish.Status);
                    cmd.Parameters.AddWithValue("@idrestaurant", dish.IdRestaurant);


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

        public int DeleteDish(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Dishes WHERE idDish=@id";
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
