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
            Id(x => x.Id);
            Map(x => x.Surname).Column("surname");
            Map(x => x.Job).Column("job");
            Map(x => x.Managerno).Column("managerno");
            Map(x => x.StartDate).Column("startdate");
            Map(x => x.Salary).Column("salary");
            Map(x => x.Commission).Column("commission");
            Map(x => x.Deptno).Column("deptno");

            HasMany(x => x.Products)
                .KeyColumn("empno")
                .Not.LazyLoad()
                .Inverse()
                .Cascade.AllDeleteOrphan()
                .Fetch.Join()
                .AsSet();
        }
    }
}