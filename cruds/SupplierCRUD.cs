using PracticaM6UF2.connections;
using PracticaM6UF2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NHibernate.Type;
using NHibernate.Driver;

namespace PracticaM6UF2.cruds
{
    public class SupplierCRUD
    {

        public IList<Supplier> SelectCreditHigherThanADO(int credit)
        {
            CloudConnection db = new CloudConnection();
            var conn = db.GetConnection();

            string query = "SELECT * FROM SUPPLIER WHERE credit > @Credit";
            using var cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("Credit", credit);
            cmd.Prepare();

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            var suppliers  = new List<Supplier>();
            ProductCRUD productCRUD = new ProductCRUD();

            while(rdr.Read())
            {
                var supplier = new Supplier
                {
                    Id = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    Address = rdr.GetString(2),
                    City = rdr.GetString(3),
                    Stcode = rdr.GetString(4),
                    Zipcode = rdr.GetString(5),
                    Area = rdr.GetInt32(6),
                    Phone = rdr.GetString(7),
                    Productno = productCRUD.SelectById(rdr.GetInt32(8)),
                    Amount = rdr.GetInt32(9),
                    Credit = rdr.GetInt32(10),
                    Remark = rdr.GetString(11)
                };
                suppliers.Add(supplier);

            }
            conn.Close();
            return suppliers;
        }


        public IList<Supplier> SelectAll()
        {
            IList<Supplier> suppliers;
            using (var session = SessionFactoryCloud.Open())
            {
                suppliers = (from s in session.Query<Supplier>() select s).ToList();
                session.Close();
            }
            return suppliers;
        }

        public void Insert(Supplier supplier)
        {
            var session = SessionFactoryCloud.Open();
            var tx = session.BeginTransaction();
            session.Save(supplier);
            tx.Commit();
            Console.WriteLine("Supplier {0} inserted", supplier.Name);
            session.Close();
        }

        public Supplier SelectById(int id)
        {
            Supplier supplier;
            var session = SessionFactoryCloud.Open();
            supplier = session.Get<Supplier>(id);
            session.Close();
            return supplier;
        }

        public void Update(Supplier supplier)
        {
            var session = SessionFactoryCloud.Open();
            var tx = session.BeginTransaction();

            try
            {
                session.Update(supplier);
                tx.Commit();
                Console.WriteLine("Supplier {0} updated", supplier.Name);
            }
            catch (Exception ex)
            {
                if (!tx.WasCommitted) tx.Rollback();
                throw new Exception("Error updating supplier : " + ex.Message);
            }

            session.Close();
        }

        public void Delete(Supplier supplier)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(supplier);
                        tx.Commit();
                        Console.WriteLine("Supplier {0} deleted", supplier.Name);
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }

                        throw new Exception("Error deleting supplier : " + ex.Message);
                    }
                }

                session.Close();
            }
        }
    }
}

