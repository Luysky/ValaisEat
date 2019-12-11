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

        public List<OrderDish> GetOrderDishes()
        {
            List<OrderDish> results = null;
           

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM OrderDish";
                    SqlCommand cmd = new SqlCommand(query, cn);

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
                            orderDishes.OrderDishPrice = (decimal)dr["Price"];


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

        public OrderDish GetOrderDish(int id)
        {
            OrderDish orderDish = null;
            

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
                        if (dr.Read())
                        {
                            orderDish = new OrderDish();

                            orderDish.IdOrder = (int)dr["IdOrder"];
                            orderDish.IdDish = (int)dr["IdDish"];
                            orderDish.Quantity = (int)dr["Quantity"];
                            orderDish.OrderDishPrice = (decimal)dr["Price"];
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

        public OrderDish AddOrderDish(OrderDish orderDish)
        {
        

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO OrderDish(IdOrder, IdDish, Quantity,Price) VALUES(@IdOrder, @ IdDish, @quantity,@price)";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@IdOrder", orderDish.Quantity);
                    cmd.Parameters.AddWithValue("@IdDish", orderDish.Quantity);
                    cmd.Parameters.AddWithValue("@quantity", orderDish.Quantity);
                    cmd.Parameters.AddWithValue("@price", orderDish.OrderDishPrice);


                    cn.Open();

                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return orderDish;
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
        public int DeleteOrderDish(int idOrder, int idDish)
        {
            int result = 0;
   

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM OrderDish WHERE IdOrder=@idIdOrder AND IdDish=@IdDish";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idIdOrder", idOrder);
                    cmd.Parameters.AddWithValue("@IdDish", idDish);

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
