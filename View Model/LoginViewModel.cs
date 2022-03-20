using System.ComponentModel.DataAnnotations;

namespace Demo.ViewModel
{
    public class LoginViewModel
    {
        [Required]
        public string USerName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string  Password { get; set; }
        public bool isPersistent { get; set; }
    }
}
