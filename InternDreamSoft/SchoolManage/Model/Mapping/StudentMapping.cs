using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using SchoolManager.Model;
using FluentNHibernate.Mapping;

namespace SchoolManage.Model.Mapping
{
    class StudentMapping : ClassMapping<Student>
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
