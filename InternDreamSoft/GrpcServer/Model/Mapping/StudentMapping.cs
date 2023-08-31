using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using FluentNHibernate.Mapping;

namespace GrpcServer
{
    public class StudentMapping : ClassMapping<Student>
    {
        public StudentMapping()
        {
            Table("Student");
            Id(x => x.Id, map => map.Column("Id"));
            Property(x => x.Name);
            Property(x => x.Address);
            Property(x => x.Dob);
            ManyToOne(x => x.ClassStudent, m => m.Column("class"));
        }
    }
}
