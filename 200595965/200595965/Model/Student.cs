
using System.ComponentModel.DataAnnotations;

namespace _200595965.Models 
{
    public class Student
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "Shubham")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "First Name must be between 2 and 50 characters")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Maan")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Last Name must be between 2 and 50 characters")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "maanshubham511@gmail.com")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [StringLength(100, ErrorMessage = "Email address cannot exceed 100 characters")]
        public string? EmailAddress { get; set; }
    }
}
