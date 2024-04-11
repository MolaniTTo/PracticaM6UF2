using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticaM6UF2.model
{
    /*CREATE TABLE ORDERP(id SERIAL NOT NULL PRIMARY KEY,
                      supplierno INTEGER,
                      orderdate TIMESTAMPTZ,
                      amount NUMERIC (12),
                      deliverydate TIMESTAMPTZ,
                      cost          DECIMAL(12,2),
					  CONSTRAINT FK_SUPP FOREIGN KEY(supplierno) REFERENCES SUPPLIER(id) ON DELETE CASCADE
					  );*/
    public class Orderp
    {
        public virtual int Id { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual double Amount { get; set; }
        public virtual DateTime DeliveryDate { get; set; }
        public virtual double Cost { get; set; }
    }
}
