using System.ComponentModel.DataAnnotations;

namespace Cowrk_Space_Mangment_System.Models
{
    public class Admin
    {
        public int ID { get; set; }
        public string Name { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string password { get; set; }


    }
}
