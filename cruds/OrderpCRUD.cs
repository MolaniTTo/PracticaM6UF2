using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaM6UF2.connections;
using PracticaM6UF2.model;

namespace PracticaM6UF2.cruds
{
    public class OrderpCRUD
    {
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
                        session.Delete(emp);
                        tx.Commit();
                        Console.WriteLine("Employee {0} deleted", emp.Surname);
                    }
                    catch (Exception ex)
                    {
                        if (!tx.WasCommitted)
                        {
                            tx.Rollback();
                        }

                        throw new Exception("Error deleting employee : " + ex.Message);
                    }
                }

                session.Close();
            }
        }
    }
}
