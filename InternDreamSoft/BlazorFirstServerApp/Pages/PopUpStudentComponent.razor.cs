using AntDesign;
using BlazorFirstServerApp.Model.DTO;
using BlazorFirstServerApp.Model.NewFolder;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Linq.Expressions;

namespace BlazorFirstServerApp.Pages
{
    public partial class PopUpStudentComponent
    {
        private List<Class> classes = new List<Class>();
        public Student student = new Student();
        [Inject] StudentMapper studentMapper { get;set; }

        private StudentAddDTO studentAddDTO = new StudentAddDTO();

        public StudentDTO studentDTO = new StudentDTO();

        [Parameter]
        public Action Clear { get; set; }

        public Boolean isCreate = true;

        private EditForm editForm;

        protected override void OnInitialized()
        {
            classes = classRepository.GetAllClass();
            base.OnInitialized();
        }

        //create new student
        private void Submit()
        {
            student = studentMapper.StudentDTOToStudent(studentDTO, isCreate);
            if(isCreate)
            {
                studentRepository.AddNewStudent(student);
            }else if (!isCreate)
            {
                studentRepository.UpdateStudentInformation(student);
            }
            Success();
            close();
        }

        private void SubmitFalse()
        {
            Error();
        }
        bool visible = false;
         public void open()
        {
            studentDTO = studentMapper.StudentToStudentDTO(student, isCreate);            
            visible = true;
        }

        public void close()
        {
            Clear?.Invoke();
            visible = false;
        }

        private void Error()
        {
            _message.Error("Something when wrong");
        }
        private void Success()
        {
            _message.Success("Successfull");
        }

    }
}
