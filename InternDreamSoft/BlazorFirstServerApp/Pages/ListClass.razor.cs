using BlazorFirstServerApp.Model.DTO;
using BlazorFirstServerApp.Model.Mapper;
using BlazorFirstServerApp.Service.IStudent;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel;

namespace BlazorFirstServerApp.Pages
{
    public partial class ListClass
    {
        bool visible = false;
        private EditForm _formInput;
        [Inject] IClassService classService { get;set; }
        string title = "List Class";
        string footer = "End";
        private EditForm editForm;
        public List<Class> listClass {  get; set; }

        public ClassDTO classObject = new ClassDTO();

        private ClassMapper classMapper = new ClassMapper();    

        protected override async Task OnInitializedAsync()
        {
            Loading();
        }
        private void Delete(Class _class)
        {
            classService.Delete(_class);
            Loading();
        }

        private void Loading()
        {
            listClass = classService.GetListClass();
            classObject = new ClassDTO();
            StateHasChanged();
        }
        public void open()
        {
            visible = true;
        }
        public void close()
        {
            visible = false;
        }

        private void SubmitFalse()
        {
            
        }
        private void Submit()
        {           
            classService.Add(classMapper.ClassDTOToClass(classObject));
            Loading();
            close();   
        }
    }
}
