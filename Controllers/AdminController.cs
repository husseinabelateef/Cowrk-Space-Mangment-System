using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class AdminController : Controller
    {
        IAdminRepository adminRepository;

        public AdminController(IAdminRepository _adminRepository)
        {
            adminRepository = _adminRepository;
        }
        public IActionResult GetAllAdmins()
        {
            List<Admin> admins = adminRepository.GetAll();
            return View(admins);
        }

        public IActionResult Details(int id)
        {
            Admin admin = adminRepository.GetById(id);
            return View(admin);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Admin admin = new Admin();

            return View(admin);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                Admin AdminModel = new Admin();
                AdminModel.Name = admin.Name;
                AdminModel.Email = admin.Email;
                AdminModel.Phone= admin.Phone;
                AdminModel.Username = admin.Username;
                AdminModel.password = admin.password;
                //save 
                adminRepository.Insert(admin);
                return RedirectToAction("GetAllAdmins");

            }
            return View(admin);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Admin admin=adminRepository.GetById(id);
            return View(admin);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Admin admin)
        {
            adminRepository.Update(admin.ID, admin);
            return RedirectToAction("GetAllAdmins");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            adminRepository.Delete(id);
            return RedirectToAction("GetAllAdmins");
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Admin admin)
        {
            adminRepository.Delete(admin.ID);
            return RedirectToAction("GetAllAdmins");
        }

    }
}
