using PracticaM6UF2.model;
using FluentNHibernate.Mapping;

namespace PracticaM6UF2.maps
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("product");
            Id(x => x.Id);
            Map(x => x.Code).Column("code");
            Map(x => x.Description).Column("description");
            Map(x => x.CurrentStock).Column("currentstock");
            Map(x => x.MinStock).Column("minstock");
            Map(x => x.Price).Column("price");
            Map(x => x.Empno).Column("empno");
            References(x => x.Employee)
                .Column("empno")
                .Not.LazyLoad()
                .Cascade.All();

        }
    }
}