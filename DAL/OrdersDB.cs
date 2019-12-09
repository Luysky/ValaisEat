using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class OrdersDB :IOrdersDB
    {

        public IConfiguration Configuration { get; }
        public OrdersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";

        public List<Order> GetOrders()
        {
            List<Order> results = null;
         

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Order";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Order>();

                            Order orders = new Order();

                            orders.IdOrder = (int)dr["IdOrder"];
                            orders.IdCustomer = (int)dr["IdCustomer"];
                            orders.IdDeliver = (int)dr["IdDeliver"];
                            orders.Status = (string)dr["Status"];
                            orders.OrderPrice = (int)dr["OrderPrice"];


                            results.Add(orders);
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

        public Order GetOrder(int id)
        {
            Order order = null;
          

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Order WHERE IdOrder = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            order = new Order();

                            order.IdOrder = (int)dr["IdOrder"];
                            order.IdCustomer = (int)dr["IdCustomer"];
                            order.IdDeliver = (int)dr["IdDeliver"];
                            order.Status = (string)dr["Status"];
                            order.OrderPrice = (int)dr["OrderPrice"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public Order AddOrder(Order order)
        {
      

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Order(IdCustomer, IdDeliver, Status, OrderPrice) VALUES(@idCustomer, @idDeliver, @status, @orderPrice); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@idCustomer", order.IdCustomer);
                    cmd.Parameters.AddWithValue("@idDeliver", order.IdDeliver);
                    cmd.Parameters.AddWithValue("@status", order.Status);
                    cmd.Parameters.AddWithValue("@orderPrice", order.OrderPrice);


                    cn.Open();

                    order.IdOrder = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return order;
        }

        public int UpdateOrder(Order order)
        {
            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                   
                    string query = "UPDATE Order SET IdCustomer=@idCustomer, IdDeliver=@idDeliver, Status=@status, OrderPrice=@orderPrice WHERE IdOrder=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                   
                    cmd.Parameters.AddWithValue("@id", order.IdOrder);
                    cmd.Parameters.AddWithValue("@idCustomer", order.IdCustomer);
                    cmd.Parameters.AddWithValue("@idDeliver", order.IdDeliver);
                    cmd.Parameters.AddWithValue("@status", order.Status);
                    cmd.Parameters.AddWithValue("@orderPrice", order.OrderPrice);


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

        public int DeleteOrder(int id)
        {
            int result = 0;
          

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Order WHERE IdOrder=@id";
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
