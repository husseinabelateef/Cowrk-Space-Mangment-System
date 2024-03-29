﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Cowrk_Space_Mangment_System.Models
{
    public class ApplicationUser : IdentityUser
    {
        //static int NoOfUsers = 0;
        //public ApplicationUser()
        //{
        //    NoOfUsers++;
        //    this.Id = NoOfUsers.ToString();
        //}
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Name Required")]
        [RegularExpression(@"^[A-Za-z]{3,}(\s[A-Za-z]{3,})+$",
        ErrorMessage = "Name is not valid")]
        public string Name { get; set; }
    }
}
