using System.Collections.Generic;

namespace PracticaM6UF2.model
{ /*CREATE TABLE EMPLOYEE ( id			SERIAL NOT NULL PRIMARY KEY,
					   surname		VARCHAR (25) NOT NULL,
                       job			VARCHAR (50),
                       managerno	INTEGER,
                       startdate	TIMESTAMPTZ,
                       salary		DECIMAL(12,2),
                       commission	DECIMAL(12,2),
					   deptno		INTEGER NOT NULL 
					   );*/
    public class Employee
    {
        public virtual int Id { get; set; }
        public virtual string Surname { get; set; }
        public virtual string Job { get; set; }
        public virtual int Managerno { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual double Salary { get; set; }
        public virtual double ? Commission { get; set; }
        public virtual int Deptno { get; set; }
        public virtual ISet<Product> Products { get; set; }
    }
}