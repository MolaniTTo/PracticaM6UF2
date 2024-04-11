using PracticaM6UF2.connections;
using PracticaM6UF2.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaM6UF2.cruds
{
    public class SupplierCRUD
    {
        
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

