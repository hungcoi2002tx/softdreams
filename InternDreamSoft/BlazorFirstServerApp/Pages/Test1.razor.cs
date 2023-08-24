using Microsoft.AspNetCore.Components;
using AntDesign.Charts;
using BlazorFirstServerApp.Model.DTO;
using AntDesign;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.Forms;

namespace BlazorFirstServerApp.Pages
{
    public partial class Test1
    {
        private readonly ColumnConfig config = new ColumnConfig
        {
            Title = new AntDesign.Charts.Title { Visible = true, Text = "Column Chart" },
            Description = new Description { Visible = true, Text = "This is a Column Chart description." }
        };

        private List<ChartData> chartData = new List<ChartData>
        {
            new ChartData { X = "January", Y = 20 },
            new ChartData { X = "February", Y = 30 },
            new ChartData { X = "March", Y = 25 },
            // Add more data points
        };

        
    }
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
}
