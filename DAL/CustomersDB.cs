using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class CustomersDB : ICustomersDB
    {

        public IConfiguration Configuration { get; }
        public CustomersDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";


        

        public Customer GetCustomer(int id)
        {
            Customer customer = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Customer WHERE IdCustomer = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            customer = new Customer();

                            customer.IdCustomer = (int)dr["IdCustomer"];
                            customer.Name = (string)dr["Name"];
                            customer.Firstname = (string)dr["Firstname"];
                            customer.Adress = (string)dr["Adress"];
                            customer.IdCity = (int)dr["IdCity"];
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }

        

    }
}
