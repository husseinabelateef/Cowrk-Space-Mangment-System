using Cowrk_Space_Mangment_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cowrk_Space_Mangment_System.Repository
{
    public class ReceptionistRepository : IReceptionistRepository
    {
        
        private readonly UserManager<ApplicationUser> userManager;
        //private readonly SignInManager<ApplicationUser> signInManager;
        //private readonly RoleManager<IdentityRole> roleManager;
        Context Entities;

        public ReceptionistRepository(UserManager<ApplicationUser> _userManager
            //, SignInManager<ApplicationUser> _signInManager
            //, RoleManager<IdentityRole> _roleManager
            , Context _Entities
            )
        {
            //this.signInManager = _signInManager;
            this.userManager = _userManager;
            //this.roleManager = _roleManager;
            this.Entities = _Entities;
        }
        public List<Receptionist> GetAll()
        {
            return Entities.Receptionist.Include(recep=>recep.Applicationuser).ToList();
        }

        public Receptionist GetById(string id)
        {
            return Entities.Receptionist.Include(x => x.Applicationuser).FirstOrDefault(r => r.AppId == id);
        }

        public int Insert(Receptionist Receptionist)
        {
            Entities.Receptionist.Add(Receptionist);
            return Entities.SaveChanges();
        }

        public async Task<int> UpdateAsync(string id, Receptionist Receptionist)
        {
            Receptionist Old_Receptionist = GetById(id);
            if (Old_Receptionist != null)
            {
                Old_Receptionist.AppId = Receptionist.AppId;
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

        public async Task<int> DeleteAsync(string id)
        {
            Receptionist receptionist = GetById(id);
            Entities.Receptionist.Remove(receptionist);
            var user = await userManager.FindByIdAsync(receptionist.AppId);

            var result = await userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                return Entities.SaveChanges();
            }
            return 0;

        }

        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public int Update(string id, Receptionist item)
        {
            throw new NotImplementedException();
        }


        int Irepository<Receptionist, string>.Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        int Irepository<Receptionist, string>.Update(string id, Receptionist item)
        {
            throw new System.NotImplementedException();
        }
    }
}
