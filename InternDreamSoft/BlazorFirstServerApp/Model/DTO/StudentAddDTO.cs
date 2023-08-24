using System.ComponentModel.DataAnnotations;

namespace BlazorFirstServerApp.Model.DTO
{
    public class StudentAddDTO
    {
        public int Id { get; set; }
        [MinLength(8, ErrorMessage = "The field must have a minimum length of 8 characters")]
        public String? Name { get; set; }
        [Required(ErrorMessage ="The field must not empty ")]
        public DateTime? Dob { get; set; }

        [MinLength(8, ErrorMessage = "The field must have a minimum length of 8 characters")]
        public String Address { get; set; }
        [Required(ErrorMessage = "The field must not empty ")]
        public int ClassId { get; set; }

        public StudentAddDTO() {
            ClassId = 0;
        }
    }
}
