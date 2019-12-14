using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class CountriesDB : ICountriesDB
    {
     
     
            public IConfiguration Configuration { get; }
            public CountriesDB(IConfiguration configuration)
            {
                Configuration = configuration;
            }
        private string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";


        public List<Country> GetCountries()
            {
                List<Country> results = null;
                

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Country";
                        SqlCommand cmd = new SqlCommand(query, cn);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (results == null)
                                    results = new List<Country>();

                                Country countries = new Country();

                                countries.IdCountry = (int)dr["IdCountry"];
                                countries.Name = (string)dr["Name"];
                             


                                results.Add(countries);
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

            public Country GetCountry(int id)
            {
                Country country = null;
                

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Country WHERE IdCountry = @id";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@id", id);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                country = new Country();

                                country.IdCountry = (int)dr["IdCountry"];
                                country.Name = (string)dr["Name"];
                              
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return country;
            }

        }
    }
