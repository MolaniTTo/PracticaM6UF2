using PracticaM6UF2.model;
using FluentNHibernate.Mapping;

namespace PracticaM6UF2.maps
{
    public class OrderpMap : ClassMap<Orderp>
    {
        /*  public class Orderp
    {
        public virtual int Id { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual DateTime OrderDate { get; set; }
        public virtual double Amount { get; set; }
        public virtual DateTime DeliveryDate { get; set; }
        public virtual double Cost { get; set; }

    }*/
        public OrderpMap()
        {
            Table("ORDERP");
            Id(x => x.Id);
            References(x => x.Supplierno)
                .Column("supplierno")
                .Not.LazyLoad()
                .Cascade.AllDeleteOrphan()
                .Fetch.Join();
            Map(x => x.OrderDate).Column("orderdate");
            Map(x => x.Amount).Column("amount");
            Map(x => x.DeliveryDate).Column("deliverydate");
            Map(x => x.Cost).Column("cost");
        }

    }
}
