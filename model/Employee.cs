using System.Collections.Generic;

namespace PracticaM6UF2.model
{
    public class Employee
    {   
        public virtual int Id { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Job { get; set; }
        public virtual int Managerno { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual double Salary { get; set; }
        public virtual double Commission { get; set; }
        public virtual int Deptno  { get; set; }
        public virtual ICollection<Product> Products { get; set; } // One to many relationship with Product
    }
}