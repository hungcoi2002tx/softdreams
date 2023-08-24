using BlazorFirstServerApp.Model.DTO;
using BlazorFirstServerApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFirstServerApp
{
    public interface IStudentRepository
    {
        public List<Student> GetAllStudents();

        public void AddNewStudent(Student student);

        public void UpdateStudentInformation( Student studentUpdate);

        public void DeleteStudent(Student student);

        public List<Student> SortData();

        public void FindStudentById();

        public Student GetStudentById(int id);

        public int GetIDNewStudent();
        

        Task<PageView<Student>> GetDataPage(int pageNumber, int pageSize, StudentSearch studentSearch);
    }
}
