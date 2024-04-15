using System;
using System.Collections.Generic;
using PracticaM6UF2.connections;
using PracticaM6UF2.model;
using System.Linq;
using System.Linq.Expressions;
using Npgsql;
using System.Xml.Linq;
using NHibernate.SqlCommand;

namespace PracticaM6UF2.cruds
{
    public class EmployeeCRUD
    {
        public Employee SelectByName(string surname)
        {
            Employee employee;
            using (var session = SessionFactoryCloud.Open())
            {
                string hql = "FROM Employee WHERE Surname = :surname";
                employee = session.CreateQuery(hql).SetParameter("surname", surname).UniqueResult<Employee>();
                session.Close();

            }
            return employee;
        }

        public Employee SelectByNameADO(string surname)
        {
            CloudConnection db = new CloudConnection();
            var conn = db.GetConnection();

            string query = $"SELECT * FROM employee WHERE surname = {surname}";
            var cmd = new NpgsqlCommand(query, conn);

            NpgsqlDataReader rdr = cmd.ExecuteReader();

            Employee employee = new Employee();

            if (rdr.Read())
            {
                employee.Id = rdr.GetInt32(0);
                employee.Surname = rdr.GetString(1);
                employee.Job = rdr.GetString(2);
                employee.Managerno = rdr.GetInt32(3);
                employee.StartDate = rdr.GetDateTime(4);
                employee.Salary = rdr.GetDouble(5);
                employee.Commission = rdr.IsDBNull(6) ? null : rdr.GetDouble(6);
                employee.Deptno = rdr.GetInt32(7);
            }

            conn.Close();
            return employee;
        }

        public void DeleteEmployeeWithADO(Employee employee)
        {

            CloudConnection db = new CloudConnection();
            var conn = db.GetConnection();

            string query = "DELETE FROM employee WHERE surname = @Surname";
            using var cmd = new NpgsqlCommand(query, conn);

            cmd.Parameters.AddWithValue("Surname", employee.Surname);
            cmd.Prepare();
            cmd.ExecuteNonQuery();

            Console.WriteLine("Employee {0} deleted", employee.Surname);
            conn.Close();
        }

        public static void InsertADO(List<Employee> employees)
        {
            string query ="INSERT INTO EMPLOYEE (surname, job, managerno, startdate, salary, commission, deptno) " +
                "VALUES (@Surname, @Job, @Managerno, @Startdate, @Salary, @Commission, @Deptno)";
            try
            {
                using (var conn = new CloudConnection().GetConnection())
                {

                    foreach (var emp in employees)
                    {
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = query;
                            cmd.Parameters.AddWithValue("@surname", emp.Surname);
                            cmd.Parameters.AddWithValue("@Job", emp.Job);
                            cmd.Parameters.AddWithValue("@Managerno", emp.Managerno);
                            cmd.Parameters.AddWithValue("@Startdate", emp.StartDate);
                            cmd.Parameters.AddWithValue("@Salary", emp.Salary);
                            cmd.Parameters.AddWithValue("@Commission", emp.Commission != null ? emp.Commission : DBNull.Value);
                            cmd.Parameters.AddWithValue("@Deptno", emp.Deptno);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    Console.WriteLine("Employees inserted");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error inserting employees: " + ex.Message);
            }
        }
        
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