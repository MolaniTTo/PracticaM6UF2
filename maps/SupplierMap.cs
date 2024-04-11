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
            Id(x => x.Id, "id").GeneratedBy.Native();
            Map(x => x.Name, "name");
            Map(x => x.Address, "address");
            Map(x => x.City, "city");
            Map(x => x.Stcode, "stcode");
            Map(x => x.Zipcode, "zipcode");
            Map(x => x.Area, "area");
            Map(x => x.Phone, "phone");
            References(x => x.Product)
                .Column("id")
                .Not.LazyLoad()
                .Fetch.Join();
            Map(x => x.Amount, "amount");
            Map(x => x.Credit, "credit");
            Map(x => x.Remark, "remark");
            HasMany(x => x.Orders)
                .KeyColumn("supplierno")
                .Cascade.All()
                .AsSet()
                .Not.LazyLoad();
        }
    }
}
