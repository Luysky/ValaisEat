using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    class OrderDishesDB : IOrderDishesDB
    {

        public IConfiguration Configuration { get; }
        public OrderDishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<OrderDish> GetOrderDishes()
        {
            List<OrderDish> results = null;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM OrderDishes";
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
                            orderDishes.OrderDishPrice = (double)dr["Price"];


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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM OrderDishes WHERE IdOrder = @id";
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
                            orderDish.OrderDishPrice = (double)dr["Price"];
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE OrderDishes SET IdDish=@idDish,Quantity=@quantity,OrderDishPrice=@orderDishPrice WHERE IdOrder=@id";
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM OrderDishes WHERE IdOrder=@id";
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
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM OrderDishes WHERE IdOrder=@idIdOrder AND IdDish=@IdDish";
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
