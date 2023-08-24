using Microsoft.AspNetCore.Components;
using AntDesign.Charts;
using BlazorFirstServerApp.Model.DTO;
using AntDesign;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Forms;
using System;
using Microsoft.VisualBasic;


namespace BlazorFirstServerApp.Pages
{
    public partial class FetchData : ComponentBase
    {
        List<ClassChartDTO> listChart = new List<ClassChartDTO>();
        List<StudentChartDTO> listChartAge = new List<StudentChartDTO>();
        FilterModel filterModel = new FilterModel();
        IChartComponent Chart;

        private Form<FilterModel> _formFilter;
        bool _visible = false;
        bool loading = false;
        private void ShowModal()
        {
            _visible = true;
        }


        void toggle(bool value) => loading = value;

        private void OnFinishFailed(EditContext editContext)
        {

        }

        private void HandleCancel(MouseEventArgs e)
        {

            _visible = false;
        }
        private void HandleOk(MouseEventArgs e)
        {
            _formFilter.Submit();
        }
        private async Task OnFinish(EditContext editContext)
        {
            await LoadDataAsync();
            _visible = false;
        }
        private async Task LoadDataAsync()
        {
            List<ClassChartDTO> listClone = new List<ClassChartDTO>();
            List<Class> listClass = classRepository.GetAllClass();
            List<Student> listStudent = studentRepository.GetAllStudents();
            foreach (Class c in listClass)
            {
                int num = 0;
                if (filterModel.Month != -1)
                    num = listStudent.Where(s => s.Dob.Value.Month == filterModel.Month).Count(s => s.ClassStudent.Id == c.Id);
                else
                {
                    num = listStudent.Count(s => s.ClassStudent.Id == c.Id);
                }
                ClassChartDTO chartDTO = new ClassChartDTO
                {
                    Name = c.Name,
                    Count = num
                };
                listClone.Add(chartDTO);
            }

            listChart = listClone.ToList();
            if (Chart != null)
            {
                await Chart.ChangeData(listChart);
                StateHasChanged();

            }

        }

        protected override async Task OnInitializedAsync()
        {
            List<Class> listClass = classRepository.GetAllClass();
            List<Student> listStudent = studentRepository.GetAllStudents();

            await LoadDataAsync();


            for (int i = 1; i <= 12; i++)
            {
                int num = listStudent.Count(s => s.Dob.Value.Month == i);
                StudentChartDTO studentChartDTO = new StudentChartDTO
                {
                    Month = i,
                    NumberOfStudent = num
                };
                listChartAge.Add(studentChartDTO);
            }
            //await base.OnInitializedAsync();

        }
        //readonly PieConfig config2 = new PieConfig
        //{
        //    ForceFit = true,
        //    Title = new AntDesign.Charts.Title
        //    {
        //        Visible = true,
        //        Text = "Student Pie Chart"
        //    },
        //    Description = new Description
        //    {
        //        Visible = true,
        //        Text = "This is Pie Chart which description the number of students in class according to Months."
        //    },
        //    Radius = 0.8,
        //    AngleField = "count",
        //    ColorField = "name",
        //    Label = new PieLabelConfig
        //    {
        //        Visible = true,
        //        Type = "inner",
        //        AutoRotate = true
        //    }
        //};


        readonly PieConfig config1 = new PieConfig
        {
            ForceFit = true,
            AngleField = "count",
            ColorField = "name",
            Label = new PieLabelConfig
            {
                Visible = false,
                Type = "inner",
                AutoRotate = true
            }
        };

    }
}
