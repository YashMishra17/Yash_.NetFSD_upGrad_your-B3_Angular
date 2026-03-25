using ConsoleApp1;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.IO;

namespace ConsoleApp1
{
    public class ProductDAL
    {
        private readonly string connectionString;

        public ProductDAL()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            connectionString = config.GetConnectionString("DefaultConnection");
        }

        // INSERT
        public void InsertProduct(Product p)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_InsertProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ProductName", p.ProductName));
                    cmd.Parameters.Add(new SqlParameter("@Category", p.Category));
                    cmd.Parameters.Add(new SqlParameter("@Price", p.Price));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Product inserted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting product: " + ex.Message);
            }
        }

        // SELECT
        public List<Product> GetProducts()
        {
            List<Product> list = new List<Product>();

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_GetAllProducts", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        list.Add(new Product
                        {
                            ProductId = Convert.ToInt32(dr["ProductId"]),
                            ProductName = dr["ProductName"].ToString(),
                            Category = dr["Category"].ToString(),
                            Price = Convert.ToDecimal(dr["Price"])
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching products: " + ex.Message);
            }

            return list;
        }

        // UPDATE
        public void UpdateProduct(Product p)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_UpdateProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ProductId", p.ProductId));
                    cmd.Parameters.Add(new SqlParameter("@ProductName", p.ProductName));
                    cmd.Parameters.Add(new SqlParameter("@Category", p.Category));
                    cmd.Parameters.Add(new SqlParameter("@Price", p.Price));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Product updated successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating product: " + ex.Message);
            }
        }

        // DELETE
        public void DeleteProduct(int id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("sp_DeleteProduct", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@ProductId", id));

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("Product deleted successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting product: " + ex.Message);
            }
        }
    }
}
