using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class CustomerLoginsDB : ICustomerLoginsDB
    {
        public IConfiguration Configuration { get; }
        public CustomerLoginsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";


        public List<CustomerLogin> GetCustomerLogins()
        {
            List<CustomerLogin> results = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM CustomerLogin";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<CustomerLogin>();

                            CustomerLogin logins = new CustomerLogin();

                            logins.IdLogin = (int)dr["IdLogin"];
                            logins.IdCustomer = (int)dr["IdCustomer"];
                            logins.Email = (string)dr["Email"];
                            logins.Password = (string)dr["Password"];



                            results.Add(logins);
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

        
        public int IsUserValid(string email, string password)
        {
            var logins = GetCustomerLogins();
            foreach (var l in logins)
            {
                if (l.Email.Equals(email))
                {
                    if (l.Password.Equals(password))
                    {
                        return l.IdCustomer;
                    }
                }
            }
            return 0;

        }
    }
}
