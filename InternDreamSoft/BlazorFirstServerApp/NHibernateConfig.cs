    using NHibernate;
    using NHibernate.Cfg.MappingSchema;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using NHibernate.Mapping.ByCode;

    using Configuration = NHibernate.Cfg.Configuration;

    namespace BlazorFirstServerApp
{
        public static class NHibernateConfig
        {
            public static ISessionFactory BuildSessionFactory() 
            {
                var cfg = new Configuration();
                string connectionString = "Data Source=DESKTOP-VM67PNO\\NGUYENMINHHUNG;Initial Catalog=SchoolManage;User ID=sa;Password=123";

                cfg.DataBaseIntegration(db =>
                {
                    db.ConnectionString = connectionString;
                    db.Dialect<MsSql2012Dialect>();
                    db.Driver<SqlClientDriver>();
                });
                var mapper = new ModelMapper();
                mapper.AddMapping(typeof(StudentMapping));
                mapper.AddMapping(typeof(TeacherMapping));
                mapper.AddMapping(typeof(ClasssMapping));
                HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
                cfg.AddMapping(domainMapping);
                return cfg.BuildSessionFactory();
            }
        }
    }
