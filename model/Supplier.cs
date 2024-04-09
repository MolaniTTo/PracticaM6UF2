using System;

namespace PracticaM6UF2.model
{
    public class Supplier
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Address { get; set; }
        public virtual string City { get; set; }
        public virtual string StCode { get; set; }
        public virtual string ZipCode { get; set; }
        public virtual int Area { get; set; }
        public virtual string Phone { get; set; }
        public virtual int ProductNo { get; set;}
        public virtual int Amount { get; set;}
        public virtual double Credit { get; set; }
        public virtual string Remark { get; set; }
        public virtual ICollection<Orderp> Orders { get; set; } // One to many relationship with Orderp
    }
}
