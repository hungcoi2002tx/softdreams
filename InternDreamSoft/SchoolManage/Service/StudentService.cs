using SchoolManager.Model;
using SchoolManager.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager
{
    class StudentService : IStudentService
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
            var student = new Student
            {
                Id = getNewId(),
                Name = Input.StringNotBlank("Enter student name: "),
                Dob = Input.Date("Enter student dob: "),
                Address = Input.StringNotBlank("Enter student address: "),
                ClassStudent = Input.ClassID("Enter class id: ", _classRepository.GetAllClass())
            };
            _studentRepository.AddNewStudent(student);
        }

        public void DeleteStudent()
        {
            int id = Input.Integer("Enter the student id: ");
            Student? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                _studentRepository.DeleteStudent(student);
            }
        }

        public void FindStudentById()
        {
            int id = Input.Integer("Enter the student id: ");
            Student? student = _studentRepository.GetStudentById(id);
            if (student == null)
            {
                Console.WriteLine("Not Found");
            }
            else
            {
                Console.WriteLine(student);
            }

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
            var students = _studentRepository.SortData();
            foreach(Student student in students)
            {
                Console.WriteLine(student);
            }
        }

        public void UpdateStudent()
        {
            List<Student> listStudent = _studentRepository.GetAllStudents();
            if (listStudent.Count == 0)
            {
                Console.WriteLine("No data can update");
            }
            else
            {
                foreach (Student student in listStudent)
                {
                    Console.WriteLine(student);
                }
                Student studentUpdate = Input.StudentId("Enter Student ID you want to update: ", listStudent);

                studentUpdate.Name = Input.StringNotBlank("Enter the new name: ");
                studentUpdate.Dob = Input.Date("Enter the new dob (dd/MM/yyyy): ");
                studentUpdate.Address = Input.StringNotBlank("Enter the new address");
                studentUpdate.ClassStudent = Input.ClassID("Enter the new id class", _classRepository.GetAllClass());          
                _studentRepository.UpdateStudentInformation(studentUpdate);
            }
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
