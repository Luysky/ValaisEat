using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    class OrderDishesDB    
    {

        public IConfiguration Configuration { get; }
        public OrderDishesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public List<OrderDish> GetOrdersDishes()
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
                    string query = "INSERT INTO OrderDish(Quantity,Price) VALUES(@Quantity,@Price); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@Quantity", orderDish.Quantity);
                    cmd.Parameters.AddWithValue("@Price", orderDish.OrderDishPrice);


                    cn.Open();

                    /*
                     * Ca c'est surement faux, il faut probablement faire une query pour récupérer
                     * les clés étrangères. A savoir IdOrder et IdDish
                     * a vérifier pour les autres cas de figure
                    */
                    orderDish.IdOrder = Convert.ToInt32(cmd.ExecuteScalar());
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
                    string query = "UPDATE OrderDishes SET idOrder=@idOrder, idDish=@idDish,quantity=@quantity,orderDishPrice=@orderDishPrice WHERE idOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idOrder", orderDish.IdOrder);
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

        public int DeleteArea(int id)
        {
            int result = 0;
            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM OrderDishes WHERE idOrder=@id";
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
