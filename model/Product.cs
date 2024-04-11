using System;

namespace PracticaM6UF2.model
{
    /*CREATE TABLE PRODUCT ( id			SERIAL NOT NULL PRIMARY KEY,
                      code			NUMERIC (12) NOT NULL,
                      description	VARCHAR (30) NOT NULL,
                      currentstock	NUMERIC (12),
                      minstock		NUMERIC (12),
                      price			DECIMAL(8,2),
					  empno			INTEGER,
					  CONSTRAINT FK_EMP FOREIGN KEY (empno) REFERENCES EMPLOYEE(id) ON DELETE CASCADE 
					  );*/


    public class Product
    {
        public virtual int Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string Description { get; set; }
        public virtual int CurrentStock { get; set; }
        public virtual int MinStock { get; set; }
        public virtual double Price { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}