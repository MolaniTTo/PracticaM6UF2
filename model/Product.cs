using System;

namespace PracticaM6UF2.model
{
    public class Product
    {
        public virtual int Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string Description { get; set; }
        public virtual int CurrentStock { get; set; }
        public virtual int MinStock { get; set; }
        public virtual double Price { get; set; }
        public virtual int Empno { get; set; }
        public virtual Employee Employee { get; set; } // Many to one relationship with Employee

    }
}