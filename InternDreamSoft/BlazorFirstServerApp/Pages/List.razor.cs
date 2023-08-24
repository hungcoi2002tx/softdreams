using AntDesign;
using AntDesign.Charts;
using BlazorFirstServerApp.Model;
using BlazorFirstServerApp.Model.DTO;
using BlazorFirstServerApp.Model.NewFolder;
using FluentNHibernate.Conventions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Net.NetworkInformation;
using System.Reflection;


namespace BlazorFirstServerApp.Pages
{
    public partial class List 
    {
        private List<StudentViewDTO> studentViews;
        public Student student = new Student();
        protected StudentSearch studentSearch = new StudentSearch();
        private int total;
        [Inject] StudentMapper studentMapper { get; set; }

        [Inject] IClassRepository classRepository { get; set; }
        private bool isCreate = true;
        private int pageNumber = 1;
        private int pageSize = 10;
        private PageView<Student> pagedData = new PageView<Student>();
        PopUpStudentComponent PopUpStudentComponent;
        private EditForm _formSearchList;
        private List<Class> classes = new List<Class>();
        bool loading = false;

        ITable table;

        /// <inheritdoc />
        protected override async Task OnInitializedAsync()
        {
            classes = classRepository.GetAllClass();
            await loadDataAsync();
        }

        private async Task loadDataAsync()
        {
            pagedData = await studentRepository.GetDataPage(pageNumber, pageSize, studentSearch);
            studentViews = studentMapper.listStudentToListStudentViewDTOWithIndex(pagedData.Data, pageSize * (pageNumber - 1));
            total = pagedData.PageCount;
            StateHasChanged();
        }

        private async Task Search(StudentSearch student)
        {        
            studentSearch = student;
            pageNumber = 1;
            await loadDataAsync();
        }


        private void DeleteStudent(StudentViewDTO student)
        {
            Student s = studentRepository.GetStudentById(student.Id);
            studentRepository.DeleteStudent(s);
            UpdateListStudents();
        }

        private void UpdateStudent(StudentViewDTO studentUpdate)
        {
            //get student update
            student = studentRepository.GetStudentById(studentUpdate.Id);
            // set up propertiy update
            PopUpStudentComponent.isCreate = false;
            PopUpStudentComponent.student = student;
            //open popup
            PopUpStudentComponent.open();
            UpdateListStudents();
        }

        private void UpdateListStudents()
        {            
            pageNumber = 1;
            loadDataAsync();
        }

        public void Clear()
        {
            student = new Student();
            PopUpStudentComponent.student = new Student();
            PopUpStudentComponent.isCreate = true;
            isCreate = true;
            studentSearch = new StudentSearch();
            
            UpdateListStudents();
        }
        public async Task OnPaging()
        {
            await loadDataAsync();
        }

        private async void OnFinishSearchAsync(EditContext editContext)
        {
            pageNumber = 1;
            await loadDataAsync();
        }

        private void OnFinishFailedSearch(EditContext editContext)
        {
            studentSearch = new StudentSearch();
        }

    }
}
