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
            Id(x => x.Id, "id").GeneratedBy.Native();
            References(x => x.Supplier)
                .Column("supplierno")
                .Not.LazyLoad()
                .Fetch.Join();
            Map(x => x.OrderDate, "orderdate");
            Map(x => x.Amount, "amount");
            Map(x => x.DeliveryDate, "deliverydate");
            Map(x => x.Cost, "cost");
        }

    }
}
