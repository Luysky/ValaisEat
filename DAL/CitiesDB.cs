using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class CitiesDB : ICitiesDB
    {
        public IConfiguration Configuration { get; }
        public CitiesDB(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";

        public List<City> GetCities()
        {
            List<City> results = null;
             

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM City";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            if (results == null)
                                results = new List<City>();

                            City cities = new City();

                            cities.IdCity = (int)dr["IdCity"];
                            cities.Name = (string)dr["Name"];
                            cities.Npa = (int)dr["Npa"];
                            cities.IdCountry = (int)dr["IdCountry"];
                            


                            results.Add(cities);
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

        public City GetCity(int id)
        {
            City city = null;
            

            try
            {
                using (SqlConnection cn = new SqlConnection(connectionString))
                {
                    string query = "SELECT * FROM City WHERE IdCity = @id";
                    SqlCommand cmd = new SqlCommand(query, cn);
                    cmd.Parameters.AddWithValue("@id", id);

                    cn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            city = new City();

                            city.IdCity = (int)dr["IdCity"];
                            city.Name = (string)dr["Name"];
                            city.Npa = (int)dr["Npa"];
                            city.IdCountry = (int)dr["IdCountry"];

                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return city;
        }
    }
}
