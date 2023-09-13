using BlazorFirstServerApp.Model;
using BlazorFirstServerApp.Model.DTO;
using BlazorFirstServerApp.Model.NewFolder;
using Microsoft.AspNetCore.Components;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFirstServerApp
{
    public class StudentRepository : IStudentRepository
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
            using (var session = _session.OpenStatelessSession())
            {
                StudentSearch studentSearch = new StudentSearch();
                var query = session.Query<Student>(); // Implement NHibernate query here
                query = Filter(query, studentSearch);
                return query.ToList();
                
            }
            
        }

        public Boolean AddNewStudent(Student student)
        {
            student.Id = GetIDNewStudent();
            using (var session = _session.OpenStatelessSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {                       
                        session.Insert(student);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public int GetIDNewStudent()
        {
            var student = GetAllStudents().OrderByDescending(x=> x.Id).First();
            return student.Id + 1;
        }

        public Boolean UpdateStudentInformation(Student student)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {  
                        session.Update(student);
                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public Boolean DeleteStudent(Student student)
        {
            using (var session = _session.OpenSession())
            {
                using (var transaction = session.BeginTransaction(IsolationLevel.Serializable))
                {
                    try
                    {
                        
                        session.Delete(student);

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public List<Student> SortData()
        {
            using (var session = _session.OpenStatelessSession())
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
                var query = session.Query<Student>();
                StudentSearch studentSearch = new StudentSearch()
                {
                    Id = id,
                };
                query = Filter(query, studentSearch);
                var student = query.ToList().FirstOrDefault();
                return student;
            }
        }

        private IQueryable<Student>? Filter(IQueryable<Student> query, StudentSearch studentSearch)
        {
            if (studentSearch.Name != null && !studentSearch.Name.Equals(""))
            {
                query = query.Where(c => c.Name.Contains(studentSearch.Name));
            }
            if (studentSearch.Address != null && !studentSearch.Address.Equals(""))
            {
                query = query.Where(c => c.Address.Contains(studentSearch.Address));
            }
            if (studentSearch.StartDate != null)
            {
                query = query.Where(student => student.Dob.Value.Date >= studentSearch.StartDate.Value.Date);
            }
            if (studentSearch.EndDate != null)
            {
                query = query.Where(student => student.Dob.Value.Date <= studentSearch.EndDate.Value.Date);
            }
            if (studentSearch.ClassID != -1)
            {
                query = query.Where(student => student.ClassStudent.Id == studentSearch.ClassID);
            }
            if (studentSearch.Id != -1)
            {
                query = query.Where(student => student.Id == studentSearch.Id);
            }
            return query;
        }



        public async Task<PageView<Student>> GetDataPage(int pageNumber, int pageSize, StudentSearch studentSearch)
        {

            //get index

            //get and convert data
            using (var session = _session.OpenSession())
            {
                var query = session.Query<Student>(); // Implement NHibernate query here
                query = Filter(query, studentSearch);
                var pagedData = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
                var total =  query.Count();
                return new PageView<Student>
                {
                    Data = pagedData,
                    PageCount = total // Đây là tổng số mục
                };
            }
        }
    }
}
