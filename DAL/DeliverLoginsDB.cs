using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using DTO;

namespace DAL
{
    public class DeliverLoginsDB : IDeliverLoginsDB
    {
        public IConfiguration Configuration { get; }
        public DeliverLoginsDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        private string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";


        public List<DeliverLogin> GetDeliverLogins()
        {
            List<DeliverLogin> results = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM DeliverLogin";
                    SqlCommand cmd = new SqlCommand(query, cn);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<DeliverLogin>();

                            DeliverLogin logins = new DeliverLogin();

                            logins.IdLogin = (int)dr["IdLogin"];
                            logins.IdDeliver = (int)dr["IdDeliver"];
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

        public DeliverLogin GetDeliverLogin(int id)
        {
            DeliverLogin login = null;


            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM DeliverLogin WHERE IdDeliver = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            login = new DeliverLogin();

                            login.IdLogin = (int)dr["IdLogin"];
                            login.IdDeliver = (int)dr["IdDeliver"];
                            login.Email = (string)dr["Email"];
                            login.Password = (string)dr["Password"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return login;
        }

        public int IsUserValid(string email, string password)
        {
            var logins = GetDeliverLogins();
            foreach (var l in logins)
            {
                if (l.Email.Equals(email))
                {
                    if (l.Password.Equals(password))
                    {
                        return l.IdDeliver;
                    }
                }
            }
            return 0;

        }
    }
}
