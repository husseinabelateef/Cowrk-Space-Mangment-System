using Cowrk_Space_Mangment_System.Models;
using Demo.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        Context Entities;

        public AccountController(UserManager<ApplicationUser> _userManager
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

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(string RoleName)
        {
            if (RoleName != null)
            {
                IdentityRole role = new IdentityRole();
                role.Name = RoleName;
                IdentityResult result = await roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Home");
                }
                else
                {
                    ViewData["Error"] = result.Errors;
                }
            }
            ViewData["RoleName"] = RoleName;
            return View();
        }



        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
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
                    IdentityResult roleResult=null;
                    if(newUser.Role == "Reciptionist")
                    {
                        //Add to Role Reciptionist
                        roleResult = await userManager.
                            AddToRoleAsync(UserModel, "Reciptionist");
                        Receptionist receptionist = new Receptionist();
                        receptionist.Applicationuser = UserModel;
                        receptionist.SalaryPerHour= newUser.SalaryPerHour;
                        Entities.Receptionist.Add(receptionist);
                        Entities.SaveChanges();
                    }
                    else if(newUser.Role=="Admin")
                    {
                        //Add to Role Admin
                        roleResult = await userManager.
                            AddToRoleAsync(UserModel, "Admin");
                    }
                    //create cookie
                    if (roleResult.Succeeded)
                    {
                        await signInManager.SignInAsync(UserModel, false);
                        return RedirectToAction("Home");
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
            return View(newUser);
        }


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
                ApplicationUser UserModel =
                    await userManager.FindByNameAsync(LoginAccount.Username);
                if (UserModel != null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult result =
                        await signInManager.PasswordSignInAsync
                        (UserModel, LoginAccount.password, LoginAccount.RemmemberMe, false);
                    return RedirectToAction("Home");
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
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
