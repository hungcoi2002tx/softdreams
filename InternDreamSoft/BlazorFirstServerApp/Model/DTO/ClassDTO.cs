using System.ComponentModel.DataAnnotations;

namespace BlazorFirstServerApp.Model.DTO
{
    public class ClassDTO
    {
        [Required(ErrorMessage = "The field must not empty !!!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The field must not empty !!!")]
        public string SubjectName { get; set; }
    }
}
