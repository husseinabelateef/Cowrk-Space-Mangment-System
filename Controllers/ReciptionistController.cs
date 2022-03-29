using Cowrk_Space_Mangment_System.Models;
using Cowrk_Space_Mangment_System.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
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
        
        [HttpPost]
        public IActionResult Details(string appid)
        {
            Receptionist receptionist = ReceptionistRepository.GetById(appid);
            return PartialView("Details", receptionist);
        }

        [HttpPost]
        public IActionResult Edit(string appid)
        {
            Receptionist Receptionist = ReceptionistRepository.GetById(appid);
            return PartialView("Edit",Receptionist);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult SaveEdit(Receptionist Receptionist)
        {
            ReceptionistRepository.UpdateAsync(Receptionist.AppId, Receptionist);
            return RedirectToAction("GetAllReceptionists");
        }

        [HttpPost]
        public IActionResult Delete(string Appid)
        {
            Receptionist receptionist= ReceptionistRepository.GetById(Appid);
            return PartialView("Delete", receptionist);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult FinalDelete(Receptionist Receptionist)
        {
            ReceptionistRepository.DeleteAsync(Receptionist.AppId);
            return RedirectToAction("GetAllReceptionists");
        }
    }
}
