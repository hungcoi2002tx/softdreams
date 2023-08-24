
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorFirstServerApp
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;

        public StudentService(IStudentRepository studentRepository, IClassRepository classRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository; 
        }

        public void AddNewStudent()
        {
            
        }

        public void DeleteStudent()
        {
            
        }

        public void FindStudentById()
        {
            

        }

        public void ListAllStudent()
        {
            List<Student> listStudent = _studentRepository.GetAllStudents();
            if (listStudent.Count == 0 ) {
                Console.WriteLine("Has 0 student");
            }
            else
            {
                foreach (Student student in listStudent)
                {
                    Console.WriteLine(student);
                }
            }
        }

        public void SortData()
        {
            
        }

        public void UpdateStudent()
        {
           
        }
        

        private int getNewId()
        {
            if(_studentRepository.GetAllStudents().Count == 0)
            {
                return 1;
            }
            var student = _studentRepository.GetAllStudents().Last();
            int result = student.Id + 1;
            return result;
        }
    }
}
