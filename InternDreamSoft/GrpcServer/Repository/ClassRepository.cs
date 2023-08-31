
using NHibernate;
using NHibernate.Linq;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrpcServer
{
    public class ClassRepository : IClassRepository
    {
        private readonly ISessionFactory _session;

        public ClassRepository(ISessionFactory session)
        {
           _session = session;
        }

        public void Add(Class _class)
        {
            _class.Id = GetNewClassID();
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Insert(_class);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
        }

        public void Delete(Class _class)
        {
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Delete(_class);
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                    }
                }
            }
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

        public int GetNewClassID()
        {
                var _class = GetAllClass().OrderByDescending(x => x.Id).First();
                return _class.Id + 1;
            
        }
    }
}
