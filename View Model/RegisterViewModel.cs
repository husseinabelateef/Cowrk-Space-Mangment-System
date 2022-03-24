using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModel
{
    public class RegisterViewModel
    {
        [Display(Name = "User Name")]
        [Required(ErrorMessage = "Name Required")]
        [RegularExpression(@"^[A-Za-z]{3,}(\s[A-Za-z]{3,})+$",
           ErrorMessage = "Name is not valid")]
        public string Name { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Required")]
        [RegularExpression(@"^(011|012|010|015)[0-9]{8}",
            ErrorMessage = "Phone is not valid")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Enter Username")]
        [MaxLength(15)]
        [MinLength(6)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        [RegularExpression(@"(Admin|Reciptionist)",
            ErrorMessage = "Role Must be Admin Or Reciptionist")]
        public string Role { get; set; }
        //for Hour
        [Required(ErrorMessage = "Please, indicate Salary Per Hour!?")]
        public double SalaryPerHour { get; set; }
    }
}
