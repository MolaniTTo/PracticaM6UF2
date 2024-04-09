using System;
using System.Collections.Generic;
using System.Linq;
using PracticaM6UF2.connections;
using PracticaM6UF2.model;
using NHibernate;

namespace cat.itb.M6UF2EA3.cruds
{
    public class ProductCRUD
    {
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