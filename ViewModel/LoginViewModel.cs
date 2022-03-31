using System.ComponentModel.DataAnnotations;

namespace Cowrk_Space_Mangment_System.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter Username")]
        [MaxLength(15)]
        [MinLength(6)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public bool RemmemberMe { get; set; }
    }
}
