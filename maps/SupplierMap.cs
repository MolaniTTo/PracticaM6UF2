using PracticaM6UF2.model;
using FluentNHibernate.Mapping;

namespace PracticaM6UF2.maps
{
    public class SupplierMap : ClassMap<Supplier>
    {
        /*public class Supplier
        {
            public virtual int Id { get; set; }
            public virtual string Name { get; set; }
            public virtual string Address { get; set; }
            public virtual string City { get; set; }
            public virtual string Stcode { get; set; }
            public virtual string Zipcode { get; set; }
            public virtual int Area { get; set; }
            public virtual string Phone { get; set; }
            public virtual Product Product { get; set; }
            public virtual int Amount { get; set; }
            public virtual double Credit { get; set; }
            public virtual string Remark { get; set; }

        }*/

        public SupplierMap()
        {
            Table("SUPPLIER");
            Id(x => x.Id);
            Map(x => x.Name).Column("name");
            Map(x => x.Address).Column("address");
            Map(x => x.City).Column("city");
            Map(x => x.Stcode).Column("stcode");
            Map(x => x.Zipcode).Column("zipcode");
            Map(x => x.Area).Column("area");
            Map(x => x.Phone).Column("phone");

            References(x => x.Productno)
                .Column("productno")
                .Not.LazyLoad()
                .Fetch.Join();

            Map(x => x.Amount).Column("amount");
            Map(x => x.Credit).Column("credit");
            Map(x => x.Remark).Column("remark");

            HasMany(x => x.Orders)
                .KeyColumn("supplierno")
                .Cascade.All()
                .AsSet()
                .Not.LazyLoad();
        }
    }
}
