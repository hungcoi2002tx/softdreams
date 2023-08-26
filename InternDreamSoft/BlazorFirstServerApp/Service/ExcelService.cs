using BlazorFirstServerApp.Model.DTO;
using BlazorFirstServerApp.Service.IStudent;
using Syncfusion.XlsIO;
using System.Data;

namespace BlazorFirstServerApp.Service
{
    public class ExcelService : IExcelService
    {
        public MemoryStream CreateExcel(List<StudentViewDTO> listStudent)
        {
            //Create an instance of ExcelEngine.
            using (ExcelEngine excelEngine = new ExcelEngine())
            {
                IApplication application = excelEngine.Excel;
                application.DefaultVersion = ExcelVersion.Xlsx;

                //Create a workbook.
                IWorkbook workbook = application.Workbooks.Create(1);
                IWorksheet worksheet = workbook.Worksheets[0];
                //Export data from DataTable to Excel worksheet.

                worksheet.ImportData(listStudent, 1,1,false);

                worksheet.UsedRange.AutofitColumns();

                //Save the document as a stream and return the stream.
                using (MemoryStream stream = new MemoryStream())
                {
                    //Save the created Excel document to MemoryStream.
                    workbook.SaveAs(stream);
                    return stream;
                }
            }
            return null;
        }
    }
    
}
