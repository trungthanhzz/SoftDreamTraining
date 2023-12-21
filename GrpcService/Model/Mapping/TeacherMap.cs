using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcService
{
    public class TeacherMap : ClassMapping<Teacher>
    {
        public TeacherMap()
        {
            Table("teacher");

            Id(x => x.Id, map => map.Column("Id"));

            Property(x => x.TeacherName);

            Property(x => x.DateOfBirth);

            Bag(x => x.Classes, c =>
            {
                c.Key(k => k.Column("TeacherId"));
                c.Cascade(Cascade.All | Cascade.DeleteOrphans);
                c.Inverse(true);
            }, r => r.OneToMany());
        }
    }
}
