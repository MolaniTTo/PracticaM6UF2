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
            Id(x => x.Id);
            Map(x => x.Code).Column("code");
            Map(x => x.Description).Column("description");
            Map(x => x.CurrentStock).Column("currentstock");
            Map(x => x.MinStock).Column("minstock");
            Map(x => x.Price).Column("price");
            References(x => x.Empno)
                .Column("empno")
                .Cascade.All()
                .Not.LazyLoad();

            HasOne(x => x.Supplierno)
                .PropertyRef(nameof(Supplier.Productno))
                .Not.LazyLoad()
                .Cascade.AllDeleteOrphan().Fetch.Join();
        }
    }
}