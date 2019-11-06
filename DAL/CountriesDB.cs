using DTO;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    class CountriesDB : ICountriesDB
    {
     
     
            public IConfiguration Configuration { get; }
            public CountriesDB(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            public List<Country> GetCountries()
            {
                List<Country> results = null;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Countries";
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
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Countries WHERE IdCountry = @id";
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

            public Country AddCountry(Country country)
            {
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Countries(name) VALUES(@name); SELECT SCOPE_IDENTITY()";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@name", country.Name);
                       


                        cn.Open();

                        country.IdCountry = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return country;
            }

            public int UpdateCountry(Country country)
            {
                int result = 0;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Countries SET name=@name WHERE idCountry=@id";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@id", country.IdCountry);
                        cmd.Parameters.AddWithValue("@name", country.Name);
                     


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

            public int DeleteCountry(int id)
            {
                int result = 0;
                string connectionString = Configuration.GetConnectionString("DefaultConnection");

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Countries WHERE idCountry=@id";
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
