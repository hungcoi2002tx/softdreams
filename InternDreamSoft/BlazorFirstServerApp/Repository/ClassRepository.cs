
using NHibernate;
using NHibernate.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFirstServerApp
{
    public class ClassRepository : IClassRepository
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

        public Class GetClassById(int id)
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Class>()
                    .Where(s => s.Id == id).First();
            }
        }
    }
}
