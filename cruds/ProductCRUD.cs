using System;
using System.Collections.Generic;
using System.Linq;
using PracticaM6UF2.connections;
using PracticaM6UF2.model;
using NHibernate;
using System.Runtime.InteropServices.Marshalling;
using Npgsql;

namespace PracticaM6UF2.cruds
{
    public class ProductCRUD
    {

        public IList<object[]> SelectByPriceLowThan(double price)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                var products = session.QueryOver<Product>()
                    .Where(p => p.Price < price)
                    .Select(p => p.Code, p => p.Description)
                    .List<object[]>();
                return products;
            }
        }
        public IList<Product> SelectByPriceLowThanWithQueryOver(double price)
        {
            IList<Product> products;
            using (var session = SessionFactoryCloud.Open())
            {
                products = session.QueryOver<Product>()
                    .Where(p => p.Price < price)
                    .Select(p => p.Code, p => p.Description)
                    .List<Product>();
                session.Close();
            }
            return products;
           
        }

        public Product SelectByCodeADO(int code)
        {
            string query = "SELECT * FROM PRODUCT WHERE CODE = @Code";

            using (NpgsqlConnection connection = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Code", code);

                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Product product = new Product();
                            product.Code = Convert.ToInt32(reader["CODE"]);
                            product.CurrentStock = Convert.ToInt32(reader["CurrentStock"]);
                            product.Description = reader["Description"].ToString();
                            product.MinStock = Convert.ToInt32(reader["MinStock"]);
                            product.Price = Convert.ToDouble(reader["Price"]);

                            // Agregar más campos según la estructura de tu tabla
                            return product;
                        }
                    }
                    connection.Close();
                }
            }

            // Si no se encuentra ningún producto con este código, se devuelve un objeto Product vacío
            return new Product();
        }

        public bool UpdateADO(Product product)
        {
            string query = "UPDATE PRODUCT SET CurrentStock = @CurrentStock WHERE CODE = @Code";

            using (NpgsqlConnection connection = new CloudConnection().GetConnection())
            {
                using (NpgsqlCommand command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CurrentStock", product.CurrentStock);
                    command.Parameters.AddWithValue("@CODE", product.Code);

                   
                    Console.WriteLine("Product {0} updated", product.Description);
                    int rowsAffected = command.ExecuteNonQuery();
                    connection.Close();
                    return rowsAffected > 0;

                }
            }
              
        }


        public IList<Product> SelectAll()
        {
            IList<Product> products;
            using (var session = SessionFactoryCloud.Open())
            {
                products = (from p in session.Query<Product>() select p).ToList();
                session.Close();
            }
            return products;
        }

        public void Insert(Product product)
        {
            var session = SessionFactoryCloud.Open();
            var tx = session.BeginTransaction();
            session.Save(product);
            tx.Commit();
            Console.WriteLine("Product {0} inserted", product.Description);
            session.Close();
        }

        public Product SelectById(int id)
        {
            Product product;
            var session = SessionFactoryCloud.Open();
            product = session.Get<Product>(id);
            session.Close();
            return product;
        }

        public void Update(Product product)
        {
            var session = SessionFactoryCloud.Open();
            var tx = session.BeginTransaction();

            try
            {
                session.Update(product);
                tx.Commit();
                Console.WriteLine("Product {0} updated", product.Description);
            }
            catch (Exception ex)
            {
                if (!tx.WasCommitted) tx.Rollback();
                throw new Exception("Error updating product : " + ex.Message);
            }

            session.Close();
        }

        public void Delete(Product prod)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(prod);
                        tx.Commit();
                        Console.WriteLine("Product {0} deleted", prod.Description);
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }

                        throw new Exception("Error deleting product : " + ex.Message);
                    }
                }

                session.Close();
            }
        }

    }
}