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
        static void Main()
        {

            //InsertEmployeesWithADO();
            //SelectByCodeADOandUpdateADO();
            //SelectOrdersSupplierADO();
            SelectSuppliersWhithCreditADO();


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


        public static void SelectByCodeADOandUpdateADO()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            Product product = productCRUD.SelectByCodeADO(100890);
            product.CurrentStock = 8;
            productCRUD.UpdateADO(product);

            product = productCRUD.SelectByCodeADO(200376);
            product.CurrentStock = 7;
            productCRUD.UpdateADO(product);

            product = productCRUD.SelectByCodeADO(200380);
            product.CurrentStock = 9;
            productCRUD.UpdateADO(product);

            product = productCRUD.SelectByCodeADO(100861);
            product.CurrentStock = 12;
            productCRUD.UpdateADO(product);
        }

        /*Mostra la quantitat total i el cost total de les comandes fetes al proveïdor amb supplierno igual a 6. Al Program.cs
        has d’obtenir una llista d’objectes Order utilitzant el mètode de OrderCRUD.cs anomenat
        SelectOrdersSupplierADO que rep com a paràmetre el id del proveïdor i retorna la llista d’objectes Order que
        tenen com supplierno el número passat com a paràmetre. Al Program.cs has de sumar totes les quantitats i tots els
        costos dels objectes Order obtinguts, i es mostrarà per pantalla el missatge «El proveïdor amb id <supplierno> ha
        facturat un total de <cost total> per una quantitat igual a <quantitat total>».*/
        public static void SelectOrdersSupplierADO()
        {
            OrderpCRUD orderpCRUD = new OrderpCRUD();
            IList<Orderp> orders = orderpCRUD.SelectOrdersSupplierADO(6);

            double totalCost = 0;
            double totalAmount = 0;

            foreach (Orderp order in orders)
            {
                totalCost += order.Cost;
                totalAmount += order.Amount;
            }

            Console.WriteLine($"El proveïdor amb id {6} ha facturat un total de {totalCost} per una quantitat igual a {totalAmount}");
        }


        public static void SelectSuppliersWhithCreditADO()
        {
            SupplierCRUD supplierCRUD = new SupplierCRUD();
            Console.WriteLine("Introduce el crédito:");
            int credit = Convert.ToInt32(Console.ReadLine());
            IList<Supplier> suppliers = supplierCRUD.SelectCreditHigherThanADO(credit);

            foreach (Supplier supplier in suppliers)
            {
                Console.WriteLine($"Id: {supplier.Id}, Name: {supplier.Name}, Credit: {supplier.Credit}");
            }

        }




    }
}
