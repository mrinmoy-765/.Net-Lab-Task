using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEST.Models
{
    public class SignUpModel
    {
        [Required(ErrorMessage = "Provide Full Name")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name should be between 3 and 50 characters")]
        [RegularExpression(@"^[a-zA-Z .-]*$", ErrorMessage = "Number,Specail Characters are NOT Allowed")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(7, MinimumLength = 5, ErrorMessage = "Username should be between 5 and 7 characters")]
        [RegularExpression(@"^[a-zA-Z0-9-_]+$", ErrorMessage = "Username can only contain numbers, underscores (_), or dashes (-)")]
        public string Username { get; set; }

        
        [Required(ErrorMessage = "Email is required")]
        [RegularExpression(@"^\d{2}-\d{5}-\d{1}@student\.aiub\.edu$", ErrorMessage = "Email must follow the format: xx-xxxxx-x@student.aiub.edu")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Student Id is required")]
        [RegularExpression(@"^\d{2}-\d{5}-[1-3]$", ErrorMessage = "Id must follow the format: xx-xxxxx-[1-3]")]
        public string StudentId { get; set; }
        









        [Required(ErrorMessage = "Please Enter Password")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [PasswordValidation(ErrorMessage = "Password must be at least 8 characters long, contain at least 2 alphabet characters, 1 number, and 2 special characters, and should not contain spaces.")] public string Password { get; set; }


        [Required(ErrorMessage = "Date of Birth is required.")]
        [DataType(DataType.Date)]
        [AgeValidation(ErrorMessage = "Age must be greater than 18.")]
        public DateTime dob { get; set; }
    }
}