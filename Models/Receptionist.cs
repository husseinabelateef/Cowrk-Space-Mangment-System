using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Receptionist
    {
        //Receptionist : (Name / Email / Phone / SSN / Username /Password / Salary / Shift)
        //public int Id { get; set; }
        //for Hour
        [Required(ErrorMessage ="Please, indicate Salary Per Hour!?")]
        public double SalaryPerHour { get; set; }

        // Total working hours without payed for 
        public int TotalHours { get; set; }
        public virtual ICollection<Incomming> Incommings { get; set; }
        [Key]
        [ForeignKey("Applicationuser")]
        public string Id { get; set; }
        public virtual ApplicationUser Applicationuser { get; set; } 


    }
}
