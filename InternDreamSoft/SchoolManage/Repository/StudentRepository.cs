using NHibernate;
using NHibernate.Linq;
using SchoolManage;
using SchoolManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    class StudentRepository : IStudentRepository
    {   
        private readonly IClassRepository _classRepository;
        private readonly ISessionFactory _session;
        public StudentRepository(IClassRepository classRepository, ISessionFactory session)
        {
            _classRepository = classRepository;
            _session = session;
        }

        public List<Student> GetAllStudents()
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .ToList();
            }
            
        }

        public int geta()
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Student>().OrderByDescending(c => c.Id).FirstOrDefault().Id;
            }

        }

        public void AddNewStudent(Student student)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        
                        session.Save(student);

                        
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

        public void UpdateStudentInformation(Student student)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {  
                        session.Update(student);
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

        public void DeleteStudent(Student student)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        
                        session.Delete(student);

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

        public List<Student> SortData()
        {
            using (var session = _session.OpenSession())
            {
                return session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .OrderBy(x => x.Name)
                    .ToList();
            }
        }

        public void FindStudentById()
        {
            throw new NotImplementedException();
        }

        public Student GetStudentById(int id)
        {
            using (var session = _session.OpenSession())
            {
                var student =  session.Query<Student>()
                    .Fetch(s => s.ClassStudent)
                    .Where(s => s.Id == id)
                    .ToList()
                    .FirstOrDefault();
                return student;
            }
        }
    }
}
