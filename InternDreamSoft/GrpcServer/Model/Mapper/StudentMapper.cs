using GrpcServer.Model.DTO;
using FluentNHibernate.Utils;
using NHibernate.Action;

namespace GrpcServer.Model.NewFolder
{
    public class StudentMapper
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;

        public StudentMapper(IStudentRepository studentRepository, IClassRepository classRepository)
        {
            _studentRepository = studentRepository;
            _classRepository = classRepository;
        }
        public StudentUpdateDTO StudentToStudentUpdateDTO(Student student)
        {
            StudentUpdateDTO studentDTO = new StudentUpdateDTO();
            studentDTO.Name = student.Name;
            studentDTO.Address = student.Address;
            studentDTO.ClassId = student.ClassStudent.Id;
            studentDTO.Dob = student.Dob;
            studentDTO.Id = student.Id;
            return studentDTO;
        }

        public Student StudentAddToStudent(StudentAddDTO studentAddDTO)
        {
            Student student = new Student();
            student.Id = _studentRepository.GetIDNewStudent();
            student.Name = studentAddDTO.Name;
            student.Address = studentAddDTO.Address;
            student.ClassStudent = _classRepository.GetClassById(studentAddDTO.ClassId);
            student.Dob = studentAddDTO.Dob;
            
            return student;

        }
        public StudentViewDTO StudentToStudentViewDTO(Student student)
        {
            StudentViewDTO studentViewDTO = new StudentViewDTO();
            studentViewDTO.Name = student.Name;
            studentViewDTO.Address = student.Address;
            String className = _classRepository.GetClassById(student.ClassStudent.Id).Name;
            studentViewDTO.ClassName = className;
            studentViewDTO.Dob = student.Dob.Value.ToString("dd/MM/yyyy");        
            studentViewDTO.Id = student.Id;
            return studentViewDTO;

        }
        public List<StudentViewDTO> listStudentToListStudentViewDTO(List<Student> list)
        {
            List<StudentViewDTO> listStudentView = new List<StudentViewDTO>();
            for(int i = 0; i<list.Count; i++)
            {
                StudentViewDTO s = StudentToStudentViewDTO(list[i]);
                s.Stt = i + 1;
                listStudentView.Add(s);
            }
            return listStudentView;
        }

        public StudentAddDTO StudentToStudentAddDTO(Student student)
        {
            throw new NotImplementedException();
        }


        public StudentDTO StudentToStudentDTO(Student student, Boolean isCreate)
        {
            //set up student DTO default;
            StudentDTO studentDTO = new StudentDTO();
            //Case: Create student
            if(isCreate)
            {
                return studentDTO;
            }
            //Case: Update Student
            else
            {
                studentDTO.Id = student.Id;
                studentDTO.Name = student.Name;
                studentDTO.Address = student.Address;
                studentDTO.Dob = student.Dob;
                studentDTO.ClassId = student.ClassStudent.Id;
                return studentDTO;
            } 
        }

        //convert student get in form to student - which act with NHibernate
        public Student StudentDTOToStudent(StudentDTO studentDTO, bool isCreate)
        {
            Student student;
            //Case: create student
            if (isCreate)
            {
                student = new Student();
                student.Id = _studentRepository.GetIDNewStudent();
                student.Name = studentDTO.Name;
                student.Address = studentDTO.Address;
                student.Dob = studentDTO.Dob;
                student.ClassStudent = _classRepository.GetClassById(studentDTO.ClassId);
                return student;

            }
            //Case: Update student
            if(!isCreate)
            {
                student = _studentRepository.GetStudentById(studentDTO.Id);
                student.Name = studentDTO.Name;
                student.Address = studentDTO.Address;
                student.Dob = studentDTO.Dob;
                student.ClassStudent = _classRepository.GetClassById(studentDTO.ClassId);
                return student;
            }

            return null;
        }

        public List<StudentViewDTO> listStudentToListStudentViewDTOWithIndex(List<Student> list, int startIndex)
        {
            List<StudentViewDTO> listStudentView = new List<StudentViewDTO>();
            for (int i = 0; i < list.Count; i++)
            {
                StudentViewDTO s = StudentToStudentViewDTO(list[i]);
                s.Stt = startIndex + i + 1;
                listStudentView.Add(s);
            }
            return listStudentView;
        }

    }
}
