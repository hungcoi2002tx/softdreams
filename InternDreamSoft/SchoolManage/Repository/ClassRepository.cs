
using NHibernate;
using NHibernate.Linq;
using SchoolManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    class ClassRepository : IClassRepository
    {
        private readonly ISessionFactory _session;

        public ClassRepository(ISessionFactory session)
        {
           _session = session;
        }

        public List<Class> GetAllClass()
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Class>()
                    .Fetch(s => s.Teacher)
                    .ToList();
            }
        }
    }
}
