using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Driver;
using NHibernate.Mapping.ByCode;
using NHibernate.Cfg.MappingSchema;
using Microsoft.Extensions.DependencyInjection;

namespace GrpcService
{
    static class NHibernateConfig
    {
        public static ISessionFactory BuildSessionFactory()
        {
            var cfg = new NHibernate.Cfg.Configuration();
            string connectionString = "Data Source=TRUNG-THANH\\TRUNGTHANH;Initial Catalog=qlsinhvien;User Id=thanhdt;Password=123456;";

            cfg.DataBaseIntegration(db =>
            {
                db.ConnectionString = connectionString;
                db.Dialect<MsSql2012Dialect>();
                db.Driver<SqlClientDriver>();
            });
            var mapper = new ModelMapper();
            mapper.AddMapping(typeof(StudentMap));
            mapper.AddMapping(typeof(TeacherMap));
            mapper.AddMapping(typeof(ClassMap));
            HbmMapping domainMapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            cfg.AddMapping(domainMapping);

            return cfg.BuildSessionFactory();
        }
    }
}
