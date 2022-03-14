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
        public double Salary { get; set; }

        // Ask for Datatype ??
        public int Shift { get; set; }
        
    }
}
