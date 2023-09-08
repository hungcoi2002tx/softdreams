﻿    using NHibernate;
    using NHibernate.Cfg.MappingSchema;
    using NHibernate.Dialect;
    using NHibernate.Driver;
    using NHibernate.Mapping.ByCode;

    using Configuration = NHibernate.Cfg.Configuration;

    namespace GrpcServer
{
        public static class NHibernateConfig
        {
            public static ISessionFactory BuildSessionFactory() 
            {
                var cfg = new Configuration();
            string connectionString = "workstation id=schoolmanage.mssql.somee.com;packet size=4096;user id=hungdeptraifb;pwd=tiancutcho;data source=schoolmanage.mssql.somee.com;persist security info=False;initial catalog=schoolmanage";

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
