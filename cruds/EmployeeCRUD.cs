using System;
using System.Collections.Generic;
using PracticaM6UF2.connections;
using PracticaM6UF2.model;
using System.Linq;

namespace PracticaM6UF2.cruds
{
    public class EmployeeCRUD
    {
        public IList<Employee> SelectAll()
        {
            IList<Employee> employees;
            using (var session = SessionFactoryCloud.Open())
            {
                employees = (from e in session.Query<Employee>() select e).ToList();
                session.Close();
            }
            return employees;
        }

        public void Insert(Employee employee)
        {
            var session = SessionFactoryCloud.Open();
            var tx = session.BeginTransaction();
            session.Save(employee);
            tx.Commit();
            Console.WriteLine("Employee {0} inserted", employee.Surname);
            session.Close();
        }

        public Employee SelectById(int id)
        {
            Employee employee;
            var session = SessionFactoryCloud.Open();
            employee = session.Get<Employee>(id);
            session.Close();
            return employee;
        }
        
        public void Update(Employee employee)
        {
            var session = SessionFactoryCloud.Open();
            var tx = session.BeginTransaction();
                
            try
            {
                session.Update(employee);
                tx.Commit();
                Console.WriteLine("Employee {0} updated", employee.Surname);
            }
            catch (Exception ex)
            {
                if (!tx.WasCommitted) tx.Rollback();
                throw new Exception("Error updating employee : " + ex.Message);
            }
            
            session.Close();
        }

        public void Delete(Employee emp)
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