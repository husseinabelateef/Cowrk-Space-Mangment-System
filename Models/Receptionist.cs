using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Receptionist
    {
        //Receptionist : (Name / Email / Phone / SSN / Username /Password / Salary / Shift)
        public int Id { get; set; }
        [Display(Name = "Reciptionist Name")]
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
        [Required(ErrorMessage ="Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        //for Hour
        [Required(ErrorMessage ="Please, indicate Salary Per Hour!?")]
        public double SalaryPerHour { get; set; }

        // Total working hours without payed for 
        public int TotalHours { get; set; }
        public virtual ICollection<Incomming> Incommings { get; set; }


    }
}
