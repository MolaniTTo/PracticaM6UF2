using PracticaM6UF2.model;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace PracticaM6UF2.connections
{
    public class SessionFactoryCloud
    {
        private static string ConnectionString = "Server=salt.db.elephantsql.com;Port=5432;Database=qjycudrm;User Id=qjycudrm;Password=QJsJC7hDPRbUmFy0eFq0ksmWZdlV5BjB;";
        private static ISessionFactory _session;

        public static ISessionFactory CreateSession()
        {
            if (_session != null) return _session;

            IPersistenceConfigurer configDb = PostgreSQLConfiguration.PostgreSQL82.ConnectionString(ConnectionString);
            FluentConfiguration configMap = Fluently.Configure().Database(configDb)
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Employee>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Orderp>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Product>())
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Supplier>());

            _session = configMap.BuildSessionFactory();

            return _session;
        }
        
        public static ISession Open()
        {
            return CreateSession().OpenSession();
        }
    }
}