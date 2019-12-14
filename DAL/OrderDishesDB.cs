using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class OrderDishesDB : IOrderDishesDB
    {

        public IConfiguration Configuration { get; }
        public OrderDishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";

        public List<OrderDish> GetOrderDishes(int id)
        {
            List<OrderDish> results = null;
           

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM OrderDish WHERE IdOrder = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);


                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<OrderDish>();

                            OrderDish orderDishes = new OrderDish();

                            orderDishes.IdOrder = (int)dr["IdOrder"];
                            orderDishes.IdDish = (int)dr["IdDish"];
                            orderDishes.Quantity = (int)dr["Quantity"];
                            orderDishes.OrderDishPrice = (decimal)dr["OrderDishPrice"];


                            results.Add(orderDishes);
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

        public OrderDish GetOrderDish(int idOrder, int idDish)
        {
            OrderDish orderDish = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM OrderDish WHERE IdOrder = @idOrder AND IdDish = @idDish";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idOrder", idOrder);
                    cmd.Parameters.AddWithValue("@idDish", idDish);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            orderDish = new OrderDish();

                            orderDish.IdOrder = (int)dr["IdOrder"];
                            orderDish.IdDish = (int)dr["IdDish"];
                            orderDish.Quantity = (int)dr["Quantity"];
                            orderDish.OrderDishPrice = (decimal)dr["OrderDishPrice"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orderDish;
        }

        public void AddOrderDish(OrderDish orderDish)
        {
        

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO OrderDish(IdOrder, IdDish, Quantity, OrderDishPrice) VALUES(@idOrder, @idDish, @quantity, @price)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idOrder", orderDish.IdOrder);
                    cmd.Parameters.AddWithValue("@idDish", orderDish.IdDish);
                    cmd.Parameters.AddWithValue("@quantity", orderDish.Quantity);
                    cmd.Parameters.AddWithValue("@price", orderDish.OrderDishPrice);


                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }            
        }

        public int UpdateOrderDish(OrderDish orderDish)
        {
            int result = 0;
          

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE OrderDish SET IdDish=@idDish,Quantity=@quantity,OrderDishPrice=@orderDishPrice WHERE IdOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", orderDish.IdOrder);
                    cmd.Parameters.AddWithValue("@idDish", orderDish.IdDish);
                    cmd.Parameters.AddWithValue("@quantity", orderDish.Quantity);
                    cmd.Parameters.AddWithValue("@orderDishesPrice", orderDish.OrderDishPrice);

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

        public int DeleteOrderDish(int idOrder)
        {
            int result = 0;
           

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM OrderDish WHERE IdOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", idOrder);

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
        public void DeleteOrderDish(int idOrder, int idDish)
        {
   
            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM OrderDish WHERE IdOrder=@IdOrder AND IdDish=@IdDish";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdOrder", idOrder);
                    cmd.Parameters.AddWithValue("@IdDish", idDish);

                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
