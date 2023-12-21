using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp
{
    public class StudentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field must not empty ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field must not empty ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The field must not empty ")]
        [Range(typeof(DateTime), "1993-01-01", "2005-01-01", ErrorMessage = "Students must be over 18 and under 30 years old")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "The field must not empty ")]
        public int ClassId { get; set; }

        public StudentDto()
        {
            ClassId = 0;
        }
    }
}
