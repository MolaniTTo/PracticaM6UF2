using PracticaM6UF2.model;
using FluentNHibernate.Mapping;

namespace PracticaM6UF2.maps
{
    public class ProductMap : ClassMap<Product>
    {
        /* public class Product
    {
        public virtual int Id { get; set; }
        public virtual int Code { get; set; }
        public virtual string Description { get; set; }
        public virtual int CurrentStock { get; set; }
        public virtual int MinStock { get; set; }
        public virtual double Price { get; set; }
        public virtual Employee Employee { get; set; }  

    }*/
        public ProductMap()
        {
            Table("PRODUCT");
            Id(x => x.Id, "id").GeneratedBy.Native();
            Map(x => x.Code, "code");
            Map(x => x.Description, "description");
            Map(x => x.CurrentStock, "currentstock");
            Map(x => x.MinStock, "minstock");
            Map(x => x.Price, "price");
            References(x => x.Employee)
                .Column("empno")
                .Cascade.All()
                .Not.LazyLoad();
            References(x => x.Supplier)
                .Column("id")
                .Cascade.All()
                .Not.LazyLoad();
        }
    }
}