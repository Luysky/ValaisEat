using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAL
{
    public class AreasDB : IAreasDB
    {
            public IConfiguration Configuration { get; }


            public AreasDB(IConfiguration configuration)
            {
                Configuration = configuration;
            }

            string connectionString = "Server=153.109.124.35;Database=ValaisEatDespair;User Id=6231db;Password=Pwd46231.;MultipleActiveResultSets=true";

            public List<Area> GetAreas()
            {
                List<Area> results = null;
              

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Area";
                        SqlCommand cmd = new SqlCommand(query, cn);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                if (results == null)
                                    results = new List<Area>();

                                Area areas = new Area();

                                areas.IdArea = (int)dr["IdArea"];
                                areas.Name = (string)dr["Name"];
                                areas.IdCountry = (int)dr["IdCountry"];
                               

                                results.Add(areas);
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

            public Area GetArea(int id)
            {
                Area area = null;
                

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Area WHERE IdArea = @id";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@id", id);

                        cn.Open();

                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                area = new Area();

                            area.IdArea = (int)dr["IdArea"];
                            area.Name = (string)dr["Name"];
                            area.IdCountry = (int)dr["IdCountry"];
                        }
                        }
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return area;
            }

            public Area AddArea(Area area)
            {
                

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Area(Name, Idcountry) VALUES(@Name, @Idcountry); SELECT SCOPE_IDENTITY()";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@name", area.Name);
                        cmd.Parameters.AddWithValue("@idcountry", area.IdCountry);
                      

                        cn.Open();

                        area.IdArea = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }

                return area;
            }

            public int UpdateArea(Area area)
            {
                int result = 0;
              

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Area SET Name=@name, IdCountry=@idCountry WHERE IdArea=@id";
                        SqlCommand cmd = new SqlCommand(query, cn);
                        cmd.Parameters.AddWithValue("@id", area.IdArea);
                        cmd.Parameters.AddWithValue("@name", area.Name);
                        cmd.Parameters.AddWithValue("@idCountry", area.IdCountry);
                      

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
             

                try
                {
                    using (SqlConnection cn = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Area WHERE IdArea=@id";
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
