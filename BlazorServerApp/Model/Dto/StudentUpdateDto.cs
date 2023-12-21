using System.ComponentModel.DataAnnotations;

namespace BlazorServerApp
{
    public class StudentUpdateDto
    {
        [Required(ErrorMessage = "The field must not empty ")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The field must not empty ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "The field must not empty ")]
        public DateTime DateOfBirth { get; set; }

        [MinLength(8, ErrorMessage = "The field must have a minimum length of 8 characters")]
        public int ClassId { get; set; }

        public StudentUpdateDto()
        {
            ClassId = 0;
        }
    }
}
