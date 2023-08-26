using BlazorFirstServerApp.Model.DTO;

namespace BlazorFirstServerApp.Service.IStudent
{
    public interface IExcelService
    {
        public MemoryStream CreateExcel(List<StudentViewDTO> listStudents);
    }
}
