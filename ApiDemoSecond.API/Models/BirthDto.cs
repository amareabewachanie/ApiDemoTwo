using System.ComponentModel.DataAnnotations;

namespace ApiDemoSecond.API.Models
{
    public class BirthDto
    {
        [Required(ErrorMessage = "First Name should not be empty")]
        [StringLength(maximumLength: 100, MinimumLength = 5, ErrorMessage = "First name should be length bentween 5 and 100 characters")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
