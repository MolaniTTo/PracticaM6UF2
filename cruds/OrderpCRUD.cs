using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Criterion;
using NHibernate;
using Npgsql;
using PracticaM6UF2.connections;
using PracticaM6UF2.model;
using PracticaM6UF2.cruds;

namespace PracticaM6UF2.cruds
{
    public class OrderpCRUD
    {

        public IList<Orderp> SelectByCostHigherThan(double cost, double amount)
        {
            IList<Orderp> orders;
            using (var session = SessionFactoryCloud.Open())
            {
                ICriteria criteria = session.CreateCriteria<Orderp>();
                criteria.Add(Restrictions.Gt("Cost", cost));
                criteria.Add(Restrictions.Gt("Amount", amount));
                orders = criteria.List<Orderp>();
                session.Close();
            }
            return orders;
        }



        public IList<Orderp> SelectOrdersSupplierADO(int providerId)
        {
            CloudConnection db = new CloudConnection();
            var conn = db.GetConnection();

            string query = "SELECT * FROM ORDERP WHERE supplierno = @SupplierNo";
            using var cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("SupplierNo", providerId);
            cmd.Prepare();

            using NpgsqlDataReader rdr = cmd.ExecuteReader();

            var orders = new List<Orderp>();
            SupplierCRUD supplierCRUD = new SupplierCRUD();

            while(rdr.Read())
            {
                var order = new Orderp
                {
                    Id = rdr.GetInt32(0),
                    Supplierno = supplierCRUD.SelectById(rdr.GetInt32(1)),
                    OrderDate = rdr.GetDateTime(2),
                    Amount = rdr.GetDouble(3),
                    DeliveryDate = rdr.GetDateTime(4),
                    Cost = rdr.GetDouble(5),
                };
                orders.Add(order);
            }
            conn.Close();
            return orders;

        }




        public IList<Orderp> SelectAll()
        {
            IList<Orderp> orders;
            using (var session = SessionFactoryCloud.Open())
            {
                orders = (from o in session.Query<Orderp>() select o).ToList();
                session.Close();
            }
            return orders;
        }

        public void Insert(Orderp order)
        {
            var session = SessionFactoryCloud.Open();
            var tx = session.BeginTransaction();
            session.Save(order);
            tx.Commit();
            Console.WriteLine("Order {0} inserted", order.Id);
            session.Close();
        }

        public Orderp SelectById(int id)
        {
            Orderp order;
            var session = SessionFactoryCloud.Open();
            order = session.Get<Orderp>(id);
            session.Close();
            return order;
        }

        public void Update(Orderp order)
        {
            var session = SessionFactoryCloud.Open();
            var tx = session.BeginTransaction();

            try
            {
                session.Update(order);
                tx.Commit();
                Console.WriteLine("Order {0} updated", order.Id);
            }
            catch (Exception ex)
            {
                if (!tx.WasCommitted) tx.Rollback();
                throw new Exception("Error updating order : " + ex.Message);
            }

            session.Close();
        }

        public void Delete(Orderp order)
        {
            using (var session = SessionFactoryCloud.Open())
            {
                using (var tx = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(order);
                        tx.Commit();
                        Console.WriteLine("Orderp {0} deleted", order.Id);
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }

                        throw new Exception("Error deleting order : " + ex.Message);
                    }
                }

                session.Close();
            }
        }
    }
}
