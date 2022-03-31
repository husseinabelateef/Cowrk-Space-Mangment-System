using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cowrk_Space_Mangment_System.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name Required")]
        [Display(Name = "Full Name")]
        [RegularExpression(@"^[A-Za-z]{3,}(\s[A-Za-z]{3,})+$",
           ErrorMessage = "Name is not valid")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "CheckEmail", controller: "Account",
             ErrorMessage = "Email Already Exist Choose Another one")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone Required")]
        [Display(Name = "Phone Number")]
        [RegularExpression(@"^(011|012|010|015)[0-9]{8}",
            ErrorMessage = "Phone is not valid")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        [MaxLength(15, ErrorMessage = "maximum Length is 15")]
        [MinLength(6, ErrorMessage = "minimum Length is 6")]
        [Remote(action: "Checkusername", controller: "Account",
             ErrorMessage = "User name Already Exist Choose Another one")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required(ErrorMessage = "Confirm Password ,Please!")]
        [DataType(DataType.Password)]
        [Compare("password")]
        public string ConfirmPassword { get; set; }
        [RegularExpression(@"(Admin|Reciptionist)",
            ErrorMessage = "Role Must be Admin Or Reciptionist")]
        public string Role { get; set; }
        //for Hour
        [Required(ErrorMessage = "Please, indicate Salary Per Hour!?")]
        public double SalaryPerHour { get; set; }
    }
}
