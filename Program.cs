using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PracticaM6UF2.connections;
using PracticaM6UF2.model;
using PracticaM6UF2.cruds;
using PracticaM6UF2.maps;

namespace PracticaM6UF2
{
    class Program
    {
        static void Main(string[] args)
        {
            

        }
        public static void InsertEmployeesWithADO()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Surname = "SMITH",
                    Job = "DIRECTOR",
                    Managerno = 9,
                    StartDate = new DateTime(1988, 12, 12),
                    Salary = 118000,
                    Commission = 52000,
                    Deptno = 10
                },
                new Employee
                {
                    Surname = "JOHNSON",
                    Job = "VENEDOR",
                    Managerno = 4,
                    StartDate = new DateTime(1992, 2, 25),
                    Salary = 125000,
                    Commission = 30000,
                    Deptno = 30
                },
                new Employee
                {
                    Surname = "HAMILTON",
                    Job = "ANALISTA",
                    Managerno = 7,
                    StartDate = new DateTime(1989, 3, 18),
                    Salary = 172000,
                    Commission = null, // O null o un valor por defecto, dependiendo de tu definición de la columna en la base de datos
                    Deptno = 10
                },
                new Employee
                {
                    Surname = "JACKSON",
                    Job = "ANALISTA",
                    Managerno = 7,
                    StartDate = new DateTime(2001, 10, 25),
                    Salary = 192000,
                    Commission = null, // O null o un valor por defecto, dependiendo de tu definición de la columna en la base de datos
                    Deptno = 10
                }
            };

            EmployeeCRUD.InsertADO(employees);
        }
    }
}
