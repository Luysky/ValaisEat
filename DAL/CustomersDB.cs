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


        public List<Customer> GetCustomers()
        {
            List<Customer> results = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM Customer";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<Customer>();

                            Customer customers = new Customer();

                            customers.IdCustomer = (int)dr["IdCustomer"];
                            customers.Name = (string)dr["Name"];
                            customers.Adresse = (string)dr["Adresse"];
                            customers.Email = (string)dr["Email"];
                            customers.Password = (string)dr["Password"];
                            customers.IdCity = (int)dr["IdCity"];




                            results.Add(customers);
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
                            customer.Adresse = (string)dr["Adresse"];
                            customer.Email = (string)dr["Email"];
                            customer.Password = (string)dr["Password"];
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

        public Customer AddCustomer(Customer customer)
        {

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO Customer(Name, Adresse, Email, Password, Idcity) VALUES(@name, @adresse, @email, @password, @idcity); SELECT SCOPE_IDENTITY()";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@name", customer.Name);
                    cmd.Parameters.AddWithValue("@adresse", customer.Adresse);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@password", customer.Password);
                    cmd.Parameters.AddWithValue("@idcity", customer.IdCity);


                    cn.Open();

                    customer.IdCustomer = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return customer;
        }

        public int UpdateCustomer(Customer customer)
        {
            int result = 0;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Customer SET Name=@name, Adresse=@adresse, Email=@email ,Password=@password, Idcity=@idcity  WHERE IdCustomer=@id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", customer.IdCustomer);
                    cmd.Parameters.AddWithValue("@name", customer.Name);
                    cmd.Parameters.AddWithValue("@adresse", customer.Adresse);
                    cmd.Parameters.AddWithValue("@email", customer.Email);
                    cmd.Parameters.AddWithValue("@password", customer.Password);
                    cmd.Parameters.AddWithValue("@idcity", customer.IdCity);


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

        public int DeleteCustomer(int id)
        {
            int result = 0;
           

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Customer WHERE IdCustomer=@id";
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

        public bool IsUserValid(Customer c, string email)
        {
            if (c.Email.Equals(email))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }


    }
}
