﻿using Cowrk_Space_Mangment_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        Context Entities;

        public ReceptionistRepository(UserManager<ApplicationUser> _userManager
            , SignInManager<ApplicationUser> _signInManager
            , RoleManager<IdentityRole> _roleManager
            , Context _Entities
            )
        {
            this.signInManager = _signInManager;
            this.userManager = _userManager;
            this.roleManager = _roleManager;
            this.Entities = _Entities;
        }
        public List<Receptionist> GetAll()
        {
            return Entities.Receptionist.ToList();
        }

        public Receptionist GetById(int id)
        {
            return Entities.Receptionist.FirstOrDefault(r => r.Id == id);
        }

        public int Insert(Receptionist Receptionist)
        {
            Entities.Receptionist.Add(Receptionist);
            return Entities.SaveChanges();
        }

        public async Task<int> UpdateAsync(int id, Receptionist Receptionist)
        {
            Receptionist Old_Receptionist = GetById(id);
            if (Old_Receptionist != null)
            {
                Old_Receptionist.Id = Receptionist.Id;
                Old_Receptionist.Applicationuser.Name =
                    Receptionist.Applicationuser.Name;
                Old_Receptionist.Applicationuser.UserName = 
                    Receptionist.Applicationuser.UserName;
                Old_Receptionist.Applicationuser.PasswordHash =
                    Receptionist.Applicationuser.PasswordHash;
                Old_Receptionist.Applicationuser.Email =
                    Receptionist.Applicationuser.Email;
                Old_Receptionist.Applicationuser.PhoneNumber =
                    Receptionist.Applicationuser.PhoneNumber;
                Old_Receptionist.SalaryPerHour =
                    Receptionist.SalaryPerHour;
                Old_Receptionist.TotalHours = Receptionist.TotalHours;

                await userManager.UpdateAsync(Old_Receptionist.Applicationuser);
                return Entities.SaveChanges();
            }
            return 0;
        }

        public async Task<int> DeleteAsync(int id)
        {
            Receptionist receptionist = GetById(id);
            Entities.Receptionist.Remove(receptionist);
            var user = await userManager.FindByIdAsync(receptionist.AppuserID);

            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Entities.SaveChanges();
            }
            return 0;

        }


        int Irepository<Receptionist, int>.Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        int Irepository<Receptionist, int>.Update(int id, Receptionist item)
        {
            throw new System.NotImplementedException();
        }
    }
}
