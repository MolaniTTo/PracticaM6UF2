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
            //SelectSuppliersWhithCreditADO();
            //SelectEmployeeByNameAndDelete();
            //InsertNewProductsAndSuppliers();
            //UpdateCreditSuppliersByCity();
            //SelectAllProducts();
            //SelectSuppliersByEmployee();
            SelectOrdersByCostAndAmount();




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

        public static void SelectEmployeeByNameAndDelete()
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            Employee employee = employeeCRUD.SelectByNameADO("SMITH");
            employeeCRUD.DeleteEmployeeWithADO(employee);

        }


        public static void InsertNewProductsAndSuppliers()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            SupplierCRUD supplierCRUD = new SupplierCRUD();

            Product product1 = new Product
            {
                Code = 100000,
                Description = "Product 1",
                CurrentStock = 10,
                MinStock = 5,
                Price = 10.5,
                Supplierno = supplierCRUD.SelectById(1)
            };

            Product product2 = new Product
            {
                Code = 100001,
                Description = "Product 2",
                CurrentStock = 15,
                MinStock = 5,
                Price = 15.5,
                Supplierno = supplierCRUD.SelectById(2)
            };

            productCRUD.Insert(product1);
            productCRUD.Insert(product2);

        }



        public static void UpdateCreditSuppliersByCity()
        {
            SupplierCRUD supplierCRUD = new SupplierCRUD();
            IList<Supplier> suppliers = supplierCRUD.SelectByCity("BURLINGAME");

            foreach (Supplier supplier in suppliers)
            {
                supplier.Credit = 10000;
                supplierCRUD.Update(supplier);
            }
        }



        public static void SelectAllProducts()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            IList<Product> products = productCRUD.SelectAll();

            foreach (Product product in products)
            {
                Console.WriteLine($"Id: {product.Id}, Code: {product.Code}, Description: {product.Description}, CurrentStock: {product.CurrentStock}, MinStock: {product.MinStock}, Price: {product.Price}, Supplier: {product.Supplierno.Name}");
            }
        }

        public static void SelectSuppliersByEmployee()
        {
            EmployeeCRUD employeeCRUD = new EmployeeCRUD();
            Employee employee = employeeCRUD.SelectByName("ARROYO");

            foreach (Product product in employee.Products)
            {
                Console.WriteLine($"Product: {product.Description}, Supplier: {product.Supplierno.Name}");
            }
        }


        public static void SelectOrdersByCostAndAmount()
        {
            OrderpCRUD orderpCRUD = new OrderpCRUD();
            IList<Orderp> orders = orderpCRUD.SelectByCostHigherThan(10000, 100);

            foreach (Orderp order in orders)
            {
                Console.WriteLine($"Id: {order.Id}, OrderDate: {order.OrderDate}, Amount: {order.Amount}, DeliveryDate: {order.DeliveryDate}, Cost: {order.Cost}, Supplier: {order.Supplierno.Name}, Phone: {order.Supplierno.Phone}");
            }
        }



         public static void SelectProductsByPrice()
        {
            ProductCRUD productCRUD = new ProductCRUD();
            IList<object[]> products = productCRUD.SelectByPriceLowThanWithQueryOver(30);

            foreach (object[] product in products)
            {
                Console.WriteLine($"Code: {product[0]}, Description: {product[1]}");
            }
           
        }




    }
}
