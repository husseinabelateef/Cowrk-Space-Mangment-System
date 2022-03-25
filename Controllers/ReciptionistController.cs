﻿using Cowrk_Space_Mangment_System.Models;
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
        public IActionResult Edit(int id)
        {
            Receptionist Receptionist = ReceptionistRepository.GetById(id);
            return View(Receptionist);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Receptionist Receptionist)
        {
            ReceptionistRepository.UpdateAsync(Receptionist.Id, Receptionist);
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
            ReceptionistRepository.DeleteAsync(Receptionist.Id);
            return RedirectToAction("GetAllReceptionists");
        }
    }
}