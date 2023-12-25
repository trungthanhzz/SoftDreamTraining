using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorServerApp
{
    public class ClassMap : ClassMapping<Class>
    {
        public ClassMap ()
        {
            Table("classroom");
            Id(x => x.Id, map => map.Column("Id"));
            Property(x => x.ClassName);
            Property(x => x.Subject);
            ManyToOne(x => x.Teacher, m => m.Column("TeacherId"));
        }
    }
}
