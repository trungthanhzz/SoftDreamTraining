using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Mapping.ByCode;


namespace GrpcService
{
    public class StudentMap : ClassMapping<Student>
    {
        public StudentMap()
        {
            Table("student");
            Id(x => x.Id, map => map.Column("Id"));
            Property(x => x.Name);
            Property(x => x.Address);
            Property(x => x.DateOfBirth);
            ManyToOne(x => x.Class, m => m.Column("ClassId"));
        }
    }
}
