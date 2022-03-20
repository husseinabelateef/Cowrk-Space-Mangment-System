using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cowrk_Space_Mangment_System.Controllers
{
    public class ReceptionistController : Controller
    {
        IReceptionistRepository ReceptionistRepository;

        public ReceptionistController(IReceptionistRepository _ReceptionistRepository)
        {
            ReceptionistRepository = _ReceptionistRepository;
        }
        public IActionResult GetAllReceptionists()
        {
            List<Receptionist> Receptionists = ReceptionistRepository.GetAll();
            return View(Receptionists);
        }

        public IActionResult Details(int id)
        {
            Receptionist Receptionist = ReceptionistRepository.GetById(id);
            return View(Receptionist);
        }
        [HttpGet]
        public IActionResult Create()
        {
            Receptionist Receptionist = new Receptionist();

            return View(Receptionist);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Receptionist Receptionist)
        {
            if (ModelState.IsValid)
            {
                Receptionist ReceptionistModel = new Receptionist();
                ReceptionistModel.Name = Receptionist.Name;
                ReceptionistModel.Email = Receptionist.Email;
                ReceptionistModel.Phone = Receptionist.Phone;
                ReceptionistModel.SalaryPerHour = Receptionist.SalaryPerHour;
                ReceptionistModel.Username = Receptionist.Username;
                ReceptionistModel.Password = Receptionist.Password;
                //save 
                ReceptionistRepository.Insert(Receptionist);
                return RedirectToAction("GetAllReceptionists");

            }
            return View(Receptionist);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Receptionist Receptionist = ReceptionistRepository.GetById(id);
            return View(Receptionist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Receptionist Receptionist)
        {
            ReceptionistRepository.Update(Receptionist.Id, Receptionist);
            return RedirectToAction("GetAllReceptionists");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Receptionist Receptionist)
        {
            ReceptionistRepository.Delete(Receptionist.Id);
            return RedirectToAction("GetAllReceptionists");
        }
    }
}
