using PracticaM6UF2.model;
using FluentNHibernate.Mapping;

namespace PracticaM6UF2.maps
{
    public class OrderpMap : ClassMap<Orderp>
    {
        public OrderpMap()
        {
            Table("orderp");
            Id(x => x.Id);
            References(x => x.Supplier).Column("supplierno");
            Map(x => x.OrderDate).Column("orderdate");
            Map(x => x.Amount).Column("amount");
            Map(x => x.DeliveryDate).Column("deliverydate");
            Map(x => x.Cost).Column("cost");
            
        }
    }
}
