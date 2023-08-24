//using AntDesign;
//using BlazorFirstServerApp.Model;
//using Microsoft.AspNetCore.Components;
//using Microsoft.AspNetCore.Components.Forms;
//using Microsoft.AspNetCore.Components.Web;
//using System.ComponentModel.DataAnnotations;

//namespace BlazorFirstServerApp.Pages
//{
//    public partial class PopUpSearchStudentComponent
//    {
//        [Parameter]
//        public StudentSearch studentSearch { get;set; }

//        private List<Class> classes = new List<Class>();
//        [Parameter]
//        public Action Clear { get; set; }
//        [Parameter]
//        public EventCallback <StudentSearch> OK { get; set; }
//        protected override void OnInitialized()
//        {
//            classes = _classRepository.GetAllClass();
//            base.OnInitialized();
//        }
//        private void OnFinishFailed(EditContext editContext)
//        {

//        }

//        bool loading = false;

//        void toggle(bool value) => loading = value;

//        bool _visible = false;

//        public void ShowModal()
//        {
//            _visible = true;
//            StateHasChanged();
//        }

//        private void HandleCancel(MouseEventArgs e)
//        {
//            Clear?.Invoke();
//            _visible = false;
//        }


//        public Form<StudentSearch> _formSearch;


//        private void OnFinish(EditContext editContext)
//        {
//            Clear?.Invoke();
//            _visible = false;
//        }

//        private void HandleOk(MouseEventArgs e)
//        {
//            OK.InvokeAsync(studentSearch);
//            _visible = false;
//        }
//    }
//}
