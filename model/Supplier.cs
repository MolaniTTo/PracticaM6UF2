using System;

namespace PracticaM6UF2.model
{
    /*CREATE TABLE SUPPLIER ( id			SERIAL NOT NULL PRIMARY KEY,
						name		VARCHAR (45) NOT NULL,
						address 	VARCHAR (40) NOT NULL,
						city		VARCHAR (30) NOT NULL,
						stcode		VARCHAR (2),
						zipcode		VARCHAR (10) NOT NULL,
						area		NUMERIC(5),
						phone		VARCHAR (10),
						productno	INTEGER NOT NULL,
						amount		NUMERIC (12),
						credit		DECIMAL(9,2),
						remark		TEXT,
						CONSTRAINT FK_PROD FOREIGN KEY (productno) REFERENCES PRODUCT(id) ON DELETE CASCADE						
						);*/

    public class Supplier
    { 
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string Stcode { get; set; }
        public virtual string Zipcode { get; set; }
        public virtual int Area { get; set; }
        public virtual string Phone { get; set; }
        public virtual Product Productno { get; set; }
        public virtual int Amount { get; set; }
        public virtual double Credit { get; set; }
        public virtual string Remark { get; set; }
        public virtual ISet<Orderp> Orders { get; set; }
    }
}
