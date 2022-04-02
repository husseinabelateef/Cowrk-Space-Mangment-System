using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Cowrk_Space_Mangment_System.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;namespace Cowrk_Space_Mangment_System.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private RoleManager<IdentityRole> roleManager;
        Context Entities;
        private ILogingRepository LogingRepository;
        private IReceptionistRepository ReceptionistRepository; 
        public AccountController(UserManager<ApplicationUser> _userManager
        , SignInManager<ApplicationUser> _signInManager
        , RoleManager<IdentityRole> _roleManager
        , Context _Entities
        , ILogingRepository _LogingRepository
        , IReceptionistRepository _ReceptionistRepository
        )
        {
            this.signInManager = _signInManager;
            this.userManager = _userManager;
            this.roleManager = _roleManager;
            this.Entities = _Entities;
            this.LogingRepository = _LogingRepository;
            this.ReceptionistRepository = _ReceptionistRepository;
        }
        private async Task<ApplicationUser>
        GetCurrentUserAsync() => await userManager.GetUserAsync(HttpContext.User); 
        [HttpGet]
     // [Authorize(Roles = "Admin")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> Register(RegisterViewModel newUser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser UserModel = new ApplicationUser();
                UserModel.Email = newUser.Email;
                UserModel.Name = newUser.Name;
                UserModel.PhoneNumber = newUser.Phone;
                UserModel.UserName = newUser.Username;
                UserModel.PasswordHash = newUser.password;
                IdentityResult result =
                await userManager.CreateAsync(UserModel, UserModel.PasswordHash);
                if (result.Succeeded)
                {
                    IdentityResult roleResult = null;
                    if (newUser.Role == "Reciptionist")
                    {
                        if (await roleManager.RoleExistsAsync("Reciptionist") == false)
                        {
                            // first we create Admin role
                            IdentityRole role = new IdentityRole();
                            role.Name = "Reciptionist";
                            await roleManager.CreateAsync(role);
                            //Add to Role Reciptionist
                            roleResult = await userManager.
                            AddToRoleAsync(UserModel, "Reciptionist");
                            Receptionist receptionist = new Receptionist();
                            receptionist.Applicationuser = UserModel;
                            receptionist.SalaryPerHour = newUser.SalaryPerHour;
                            Entities.Receptionist.Add(receptionist);
                            Entities.SaveChanges();
                        }
                        else
                        {
                            //Add to Role Reciptionist
                            roleResult = await userManager.
                            AddToRoleAsync(UserModel, "Reciptionist");
                            Receptionist receptionist = new Receptionist();
                            receptionist.Applicationuser = UserModel;
                            receptionist.SalaryPerHour = newUser.SalaryPerHour;
                            Entities.Receptionist.Add(receptionist);
                            Entities.SaveChanges();
                        }
                    }
                    else if (newUser.Role == "Admin")
                    { // In Startup iam creating first Admin Role and creating a default Admin User
                        if (await roleManager.RoleExistsAsync("Admin") == false)
                        {
                            // first we create Admin rool
                            IdentityRole role = new IdentityRole();
                            role.Name = "Admin";
                            await roleManager.CreateAsync(role); //Add to Role Admin
                            roleResult = await userManager.
                            AddToRoleAsync(UserModel, "Admin");
                        }
                        else
                        {
                            //Add to Role Admin
                            roleResult = await userManager.
                            AddToRoleAsync(UserModel, "Admin");
                        }
                    }
                    //create cookie
                    if (roleResult.Succeeded)
                    {
                        await signInManager.SignInAsync(UserModel, false);
                        return View("Login");
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View("Register", newUser);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel LoginAccount)
        {
            if (ModelState.IsValid)
            {
                var UserModel =
                await userManager.FindByNameAsync(LoginAccount.Username);
                if (UserModel != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result =
                    await signInManager.PasswordSignInAsync
                    (UserModel, LoginAccount.password, LoginAccount.RemmemberMe, false);
                    //Check user role to add Logging Record As Reciptionist
                    if (await userManager.IsInRoleAsync(UserModel, "Reciptionist"))
                    {
                        Loging loging = new Loging();
                        loging.Receptionst_Id = UserModel.Id;
                        loging.Login = DateTime.Now;
                        LogingRepository.Insert(loging);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Username & password Invalid");
                }
            }
            return View(LoginAccount);
        }
        public async Task<IActionResult> LogOut()
        {
            var UserModel = await GetCurrentUserAsync();
            //ApplicationUser UserModel = await userManager.FindByNameAsync(User.Identity.Name);
            //Check user role to add Logging Record As Reciptionist
            if (await userManager.IsInRoleAsync(UserModel, "Reciptionist"))
            {
                Receptionist receptionist = ReceptionistRepository.GetById(UserModel.Id);
                Loging loging = LogingRepository.GetbyReceptionistId(UserModel.Id);
                loging.LogOut = DateTime.Now;
                loging.TotalHours = (loging.LogOut - loging.Login).Hours;
                LogingRepository.Update(loging.Id, loging);
                receptionist.TotalHours += loging.TotalHours;
                await ReceptionistRepository.UpdateAsync(UserModel.Id, receptionist);
            }
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult Checkusername(string Username)
        {
            Receptionist receptionist = Entities.Receptionist.
            FirstOrDefault(recept => recept.Applicationuser.UserName == Username);
            if (receptionist == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
        public IActionResult CheckEmail(string Email)
        {
            Receptionist receptionist = Entities.Receptionist.
            FirstOrDefault(recept => recept.Applicationuser.Email == Email);
            if (receptionist == null)
            {
                return Json(true);
            }
            else
            {
                return Json(false);
            }
        }
    }
}

