using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Receptionist
    {
        //Receptionist : (Name / Email / Phone / SSN / Username /Password / Salary / Shift)
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        //for Hour
        public double SalaryPerHour { get; set; }

        // Total working hours without payed for 
        public int TotalHours { get; set; }
        public virtual ICollection<Incomming> Incommings { get; set; }


    }
}
