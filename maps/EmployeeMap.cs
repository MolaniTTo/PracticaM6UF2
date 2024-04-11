using PracticaM6UF2.model;
using FluentNHibernate.Mapping;

namespace PracticaM6UF2.maps
{
    public class EmployeeMap : ClassMap<Employee>
    {
        /* public class Employee
    {  
        public virtual int Id { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Job { get; set; }
        public virtual int Managerno { get; set; }
        public virtual DateTime StartDate { get; set; }

        public virtual double Salary { get; set; }
        public virtual double Commission { get; set; }
        public virtual int Deptno { get; set; }


       
    }*/
        public EmployeeMap()
        {
            Table("EMPLOYEE");
            Id(x => x.Id, "id").GeneratedBy.Native();
            Map(x => x.Surname, "surname");
            Map(x => x.Job, "job");
            Map(x => x.Managerno, "managerno");
            Map(x => x.StartDate, "startdate");
            Map(x => x.Salary, "salary");
            Map(x => x.Commission, "commission");
            Map(x => x.Deptno, "deptno");
            HasMany(x => x.Products)
                .KeyColumn("empno")
                .Cascade.AllDeleteOrphan()
                .AsSet()
                .Not.LazyLoad();
        }
    }
}